using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    //VARS
    public GameObject Target;
    public float Speed;
    public float Health;
    public float Attack;
    public Vector3 dir;

    public GameObject[] imatges;

    public GameObject Blood;
    public int xp;

    public GameObject ugh;
    public GameObject coin;

    public GameObject Bullet;

    Vector3 targetPos;
    Vector3 myPos;

    PlayerController player;

    //ATTACK
    public float attackCooldown=1;
    float wait=0;
    bool inRange = false;
    Base BaseSript;

    GameObject GameManager;

    // Use this for initialization
    void Start () {
        //Target = GameObject.FindGameObjectWithTag ( "Base" );
        //setDir();
       GameManager = GameObject.FindGameObjectWithTag("GameController");
       player= GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
        
        if (inRange == true)
        {
            if (Target == null)//per quan es destrueixen les petites
            { 
                Target = GameObject.FindGameObjectWithTag("Base");
                setDir();
            }

            wait-= Time.deltaTime;
            if (wait <= 0)
            {
                if (Bullet != null)
                {
                   GameObject newBullet = Instantiate(Bullet, this.transform.position, Quaternion.identity);
                    newBullet.GetComponent<EnemyBullet>().direction = dir;
                }
                else { BaseSript.GetDamaged(Attack); }
                
                wait = attackCooldown;
            }
        }
        else
        {
            transform.Translate(dir * Speed * Time.deltaTime);
        }        
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Base" || other.tag == "Building")
        {            
            BaseSript = other.GetComponent<Base>();
            inRange = true;
        }
        else if (other.tag == "Bullet")
        {
            if (!other.GetComponent<bullet>().penetrate) //si no es la del sniper destruim la bala
                Destroy(other.gameObject);
            else //si es bala del franco mirar si ha tocat algu per fer lo de blind
                other.GetComponent<bullet>().touchedEnemey = true;
            GetDamaged(other.GetComponent<bullet>().damage);            
            
        }
    }

    public void setDir() {
        targetPos = new Vector3(Target.transform.position.x, Target.transform.position.y, Target.transform.position.z);
        myPos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);

        dir = new Vector3(targetPos.x - myPos.x, targetPos.y - myPos.y, targetPos.z - myPos.z);
        dir = Vector3.Normalize(dir);
        if ((Target.tag == "Base"|| Target.tag == "Building"))
        {            
            imatges[1].SetActive(true);
            imatges[0].SetActive(false);
            if(Bullet != null)
                inRange = true;
        }
    }
    
    public void Buff()
    {
        Speed *= 2;
        attackCooldown *= 0.5f;
        imatges[1].SetActive(true);
        imatges[0].SetActive(false);
    }

    public void GetDamaged (float dmg)
    {
        Health -= dmg;

        Instantiate(ugh, transform.position, Quaternion.identity);

        if (Health <= 0) {
            int prov = Random.Range(0, 100);
            imatges[1].SetActive(false);
            imatges[0].SetActive(false);
            imatges[2].SetActive(true);
            if (prov <= 20 
                && GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().GetUnlockedWeapons().Count > 1)
            {
                Instantiate(coin, transform.position, Quaternion.identity);
                GameObject Player = GameObject.FindGameObjectWithTag("Player");
                int wep = Random.Range(1, Player.GetComponent<PlayerController>().GetUnlockedWeapons().Count);
                switch (wep)
                {
                    case 1:
                        Player.GetComponent<PlayerController>().GetUnlockedWeapons()[wep].ammo += 50;
                        break;
                    case 2:
                        Player.GetComponent<PlayerController>().GetUnlockedWeapons()[wep].ammo += 5;
                        break;
                    case 3:
                        Player.GetComponent<PlayerController>().GetUnlockedWeapons()[wep].ammo += 3;
                        break;
                    case 4:
                        Player.GetComponent<PlayerController>().GetUnlockedWeapons()[wep].ammo += 6;
                        break;
                }
                
            }
            Instantiate(Blood, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);

            player.gainxp(xp);
        }


            
    }
}
