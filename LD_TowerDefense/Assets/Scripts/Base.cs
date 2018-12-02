using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour {

    public float health=5;

    public bool ammo, heal;

    float cooldown=5;
    float time=5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (ammo)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                int wep = Random.Range(1, 4);
                GameObject Player = GameObject.FindGameObjectWithTag("Player");
                Player.GetComponent<PlayerController>().GetUnlockedWeapons()[1].ammo += 50;
                Player.GetComponent<PlayerController>().GetUnlockedWeapons()[2].ammo += 5;
                Player.GetComponent<PlayerController>().GetUnlockedWeapons()[3].ammo += 3;
                time = cooldown;
            }
        }
        if (heal)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                int wep = Random.Range(1, 4);
                GameObject Base = GameObject.FindGameObjectWithTag("Base");
                Base.GetComponent<Base>().health += 50;
                if(Base.GetComponent<Base>().health > 500) { Base.GetComponent<Base>().health = 500; }
                time = cooldown;
            }
        }


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "EnemyBullet")
        {
            health -= 15;
        }
    }

}
