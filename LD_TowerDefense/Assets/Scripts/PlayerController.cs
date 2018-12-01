using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //Shooting
    [System.Serializable]
    public struct Weapon
    {
        public float fireRate;        
        public GameObject bullet;        
    }
    private Weapon equipedWeapon;
    private float nextFire;
    public Weapon[] weapons;
    public Transform fireSpawn;

    //movement
    public float speed;
    private bool moving;
    Vector3 dir = Vector3.zero;

    // Use this for initialization
    void Start () {
        equipedWeapon = weapons[0];	  
	}
	
	// Update is called once per frame
	void Update () {

        Move();

        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + equipedWeapon.fireRate;
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        if (moving)             
             transform.position += dir * speed * Time.deltaTime;

    }

    void Move()
    {
        //Rotations
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0, 0, 225);
            dir.x = -1;
            dir.y = 1;
            moving = true;
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0, 0, 135);
            dir.x = 1;
            dir.y = 1;
            moving = true;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = transform.rotation = Quaternion.Euler(0, 0, 180);
            dir.x = 0;
            dir.y = 1;
            moving = true;
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0, 0, 315);
            moving = true;
            dir.x = -1;
            dir.y = -1;
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0, 0, 45);
            moving = true;
            dir.x = 1;
            dir.y = -1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = transform.rotation = Quaternion.Euler(0, 0, 0);
            moving = true;
            dir.x = 0;
            dir.y = -1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = transform.rotation = Quaternion.Euler(0, 0, 270);
            moving = true;
            dir.x = -1;
            dir.y = 0;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = transform.rotation = Quaternion.Euler(0, 0, 90);
            moving = true;
            dir.x = 1;
            dir.y = 0;
        }
        else
            moving = false;        

    }

    public void Shoot()
    {        
        GameObject b = Instantiate(equipedWeapon.bullet, fireSpawn.position, transform.rotation);
        b.GetComponent<bullet>().direction -= transform.up;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
              
        }
    }    
}
