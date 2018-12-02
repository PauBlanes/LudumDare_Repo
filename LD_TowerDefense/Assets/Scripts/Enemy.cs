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

    public GameObject Bullet;

    Vector3 targetPos;
    Vector3 myPos;

    //ATTACK
    public float attackCooldown=1;
    float wait=0;
    bool inRange = false;
    Base BaseSript;

    // Use this for initialization
    void Start () {
        //Target = GameObject.FindGameObjectWithTag ( "Base" );
        //setDir();
       
	}
	
	// Update is called once per frame
	void Update () {
        
        if (inRange == true)
        {

            wait-= Time.deltaTime;
            if (wait <= 0)
            {
                if (Bullet != null)
                {
                   GameObject newBullet = Instantiate(Bullet, this.transform.position, Quaternion.identity);
                    newBullet.GetComponent<EnemyBullet>().direction = dir;
                }
                else { BaseSript.health -= Attack; }
                
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
        if (other.tag == "Base")
        {
            BaseSript = other.GetComponent<Base>();
            inRange = true;
        }
        else if (other.tag == "Bullet")
        {
            if (!other.GetComponent<bullet>().penetrate) //si no es la del sniper destruim la bala
                Destroy(other.gameObject);
            Health-=other.GetComponent<bullet>().damage;
            
            if (Health <= 0)
                Destroy(this.gameObject);
        }
        else if (other.tag == "Player")
        {
            Destroy(other.gameObject);
            GameObject GameManager = GameObject.FindGameObjectWithTag("GameController");
            GameManager.GetComponent<EnemyManager>().GameOver();
        }
    }

    public void setDir() {
        targetPos = new Vector3(Target.transform.position.x, Target.transform.position.y, Target.transform.position.z);
        myPos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);

        dir = new Vector3(targetPos.x - myPos.x, targetPos.y - myPos.y, targetPos.z - myPos.z);
        dir = Vector3.Normalize(dir);
        if (Target.tag == "Base" && Bullet != null)
        {
            inRange = true;
        }
    }
}
