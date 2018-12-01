using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //Shooting   
    private Weapon equipedWeapon;    
    public Weapon[] weapons; //totes les armes que pots tenir
    private float nextFire; //contador para hacer el ratio de disparo
    public Transform fireSpawn; //posicio on spawnegen les bales

    //movement
    public float speed;    
    Vector3 dir = Vector3.zero;

    //Aim    
    Vector3 aimDirection;
    public float firePointDistance;

    // Use this for initialization
    void Start () {
        equipedWeapon = weapons[0];	  
	}
	
	// Update is called once per frame
	void Update () {

        /*if (Move())
            transform.position += dir * speed * Time.deltaTime; */

        if (Input.GetMouseButton(0) && Time.time > nextFire)
        {
            nextFire = Time.time + equipedWeapon.fireRate;
            equipedWeapon.Shoot(fireSpawn.position, aimDirection.normalized);
        }

        Aim();
    }    

    bool Move()
    {
        //Rotations
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0, 0, 225);
            dir.x = -1;
            dir.y = 1;
            return true;
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0, 0, 135);
            dir.x = 1;
            dir.y = 1;
            return true;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = transform.rotation = Quaternion.Euler(0, 0, 180);
            dir.x = 0;
            dir.y = 1;
            return true;
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0, 0, 315);            
            dir.x = -1;
            dir.y = -1;
            return true;
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0, 0, 45);            
            dir.x = 1;
            dir.y = -1;
            return true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = transform.rotation = Quaternion.Euler(0, 0, 0);           
            dir.x = 0;
            dir.y = -1;
            return true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = transform.rotation = Quaternion.Euler(0, 0, 270);           
            dir.x = -1;
            dir.y = 0;
            return true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = transform.rotation = Quaternion.Euler(0, 0, 90);            
            dir.x = 1;
            dir.y = 0;
            return true;
        }

        return false;        

    }
    
    void Aim()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        aimDirection = mousePos - transform.position;
        aimDirection = Vector3.Normalize(aimDirection)*firePointDistance;

        fireSpawn.transform.position = transform.position + aimDirection;        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
              
        }
    }    
}
