﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Base : MonoBehaviour {

    public float health=5;
    private float maxHealth;

    public bool ammo, heal;
    public GameObject healText;
    public GameObject ammoIcon;

    bool gameOver=false;
    float dead = 1;
    public GameObject Boom;

    float cooldown=5;
    float time=5;

    public GameObject healthBar;   

    public Text GameOverText;

	// Use this for initialization
	void Start () {
        maxHealth = health;        
	}
	
	// Update is called once per frame
	void Update () {

        if (ammo)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                if (ammoIcon != null)
                    StartCoroutine(ShowAndHide(ammoIcon, 0.75f));

                int wep = Random.Range(1, 4);
                GameObject Player = GameObject.FindGameObjectWithTag("Player");
                if (Player.GetComponent<PlayerController>().GetUnlockedWeapons().Count>=4)
                {
                    Player.GetComponent<PlayerController>().GetUnlockedWeapons()[1].ammo += 50;
                    Player.GetComponent<PlayerController>().GetUnlockedWeapons()[2].ammo += 5;
                    Player.GetComponent<PlayerController>().GetUnlockedWeapons()[3].ammo += 3;                    
                    Player.GetComponent<PlayerController>().GetUnlockedWeapons()[4].ammo += 6;
                }
                else if (Player.GetComponent<PlayerController>().GetUnlockedWeapons().Count >= 3)
                {
                    Player.GetComponent<PlayerController>().GetUnlockedWeapons()[1].ammo += 50;
                    Player.GetComponent<PlayerController>().GetUnlockedWeapons()[2].ammo += 5;
                }
                else if (Player.GetComponent<PlayerController>().GetUnlockedWeapons().Count >= 2)
                {
                    Player.GetComponent<PlayerController>().GetUnlockedWeapons()[1].ammo += 50;
                }

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
                if (healText != null)
                    StartCoroutine(ShowAndHide(healText, 0.75f));
                if (Base.GetComponent<Base>().health > 500) { Base.GetComponent<Base>().health = 500; }
                time = cooldown;
            }
        }

        if (gameOver)
        {
            dead -= Time.deltaTime;
            if (dead < 0)
            {
                SceneManager.LoadScene(0);
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "EnemyBullet")
        {
            GetDamaged(15);
        }
    }

    public void GetDamaged(float damage)
    {
        
        health -= damage;
        healthBar.GetComponent<Image>().fillAmount = health/maxHealth;

        if (health <= 0)
        {           
            if (ammo)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<SacrificeWeapon>().StartSacrifice(this.gameObject);
                
            }
            else if (heal)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<SacrificeWeapon>().StartSacrifice(this.gameObject);
                
            }
            else {
                
                Debug.Log("GAME OVER");
                GameOverText.gameObject.SetActive(true);
                gameOver = true;
                Time.timeScale = 0.2f;
            }
                           
        }
    }

    public void KillNearEnemies()
    {
        float destroyRadius = 10;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            if ((enemy.transform.position - transform.position).magnitude < destroyRadius)
            {
                Destroy(enemy);
            }
        }
    }

    IEnumerator ShowAndHide(GameObject g, float time)
    {
        g.SetActive(true);
        yield return new WaitForSeconds(time);
        g.SetActive(false);
    }

}
