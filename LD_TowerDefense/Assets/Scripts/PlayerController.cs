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

    //Metralleta tiempo que mantienes el máximo fire rate
    private float metralletaContador;
    private bool exhaustedMetralleta; 

    // Use this for initialization
    void Start () {
        equipedWeapon = weapons[1];	  
	}
	
	// Update is called once per frame
	void Update () {

        /*if (Move())
            transform.position += dir * speed * Time.deltaTime; */
        
        //APUNTAR
        Aim();

        //DISPARAR
        if (Input.GetMouseButton(0) && Time.time > nextFire 
            && equipedWeapon.type != Weapon.WeaponType.Pistola && !exhaustedMetralleta)//No es de tipo pistola
        {
            nextFire = Time.time + equipedWeapon.fireRate;
            if (!equipedWeapon.shooting)
            {
                metralletaContador = 0;
                equipedWeapon.shooting = true;
            }
            equipedWeapon.Shoot(fireSpawn.position, aimDirection.normalized);
        } //Es pistola -> Disparar solo con click, no se puede mantener.
        else if (Input.GetMouseButtonDown(0) && equipedWeapon.type == Weapon.WeaponType.Pistola)
        {
            equipedWeapon.shooting = true;                
            equipedWeapon.Shoot(fireSpawn.position, aimDirection.normalized);
        }

        if (Input.GetMouseButtonUp(0) && equipedWeapon.shooting)
        {
            equipedWeapon.shooting = false;
            if (exhaustedMetralleta) exhaustedMetralleta = false;
        }
            
        
        //SI ES METRALLETA -> MECANICA DE ESPERAR
        if (equipedWeapon.type == Weapon.WeaponType.Metralleta)
            MetralletaRoutine();
        
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

    void MetralletaRoutine ()
    {
        if (!equipedWeapon.shooting)
        {            
            equipedWeapon.fireRate -= Time.deltaTime/8; //cada segundo ganas 0.1
            equipedWeapon.fireRate = Mathf.Clamp(equipedWeapon.fireRate, 0.05f, 1);
        }
        else
        {
            //equipedWeapon.fireRate += Time.deltaTime / 2; //cada segundo pierdes 0.2
            metralletaContador += 0.0005f;
            equipedWeapon.fireRate *= Mathf.Pow(1.05f, metralletaContador);         
            equipedWeapon.fireRate = Mathf.Clamp(equipedWeapon.fireRate, 0.05f, 0.8f);
            if (Mathf.Approximately(equipedWeapon.fireRate, 0.8f))
            {
                exhaustedMetralleta = true;
            }
        }
    }    
}
