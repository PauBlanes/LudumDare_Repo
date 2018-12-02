using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //Shooting   
    private Weapon equipedWeapon;    
    public Weapon[] allWeapons; //totes les armes que pots tenir
    private List<Weapon> unlockedWeapons = new List<Weapon>(); //les que tens ara
    private float nextFire; //contador para hacer el ratio de disparo
    public Transform fireSpawn; //posicio on spawnegen les bales

    //movement
    /*public float speed;    
    Vector3 dir = Vector3.zero;*/

    //Aim    
    /*Vector3 aimDirection;
    public float firePointDistance;*/

    //Metralleta tiempo que mantienes el máximo fire rate
    private float metralletaContador; //a lo que elevem la base per fer la curva exponencial
    private bool exhaustedMetralleta;

    //Canviar de arma
    private int weaponIndex;

    // Use this for initialization
    void Start () {
        //Només té la pistola i és la que té seleccionada
        unlockedWeapons.Add(allWeapons[0]);
        equipedWeapon = unlockedWeapons[0];     
    }
	
	// Update is called once per frame
	void Update () {
        
        //MOURE
        /*if (Move())
            transform.position += dir * speed * Time.deltaTime; */

        //APUNTAR
        //Aim();

        //Mirar el mouse
        LookAt();

        //DISPARAR
        Shoot();

        //SI ES METRALLETA -> MECANICA DE ESPERAR
        if (equipedWeapon.type == Weapon.WeaponType.Metralleta)
            MetralletaRoutine();

        //CANVIAR DE ARMAS
        ChangeWeapon();
                     
    }

    void Shoot()
    {
        if (Input.GetMouseButton(0) && Time.time > nextFire
            && equipedWeapon.canMaintainFire && !exhaustedMetralleta)//No es de tipo pistola
        {
            nextFire = Time.time + equipedWeapon.fireRate;
            if (!equipedWeapon.Shooting)
            {
                metralletaContador = 0;
                equipedWeapon.Shooting = true;
            }

            //Shooting
            if (equipedWeapon.type == Weapon.WeaponType.Lanzagranadas)
                equipedWeapon.ShootGrenade(GetMousePosInWorld());
            else if (equipedWeapon.type == Weapon.WeaponType.Revolver)
                equipedWeapon.ShootRevolver(fireSpawn.position, (fireSpawn.position - transform.position).normalized, this);
            else
                equipedWeapon.Shoot(fireSpawn.position, (fireSpawn.position - transform.position).normalized);

        } //Es pistola -> Disparar solo con click, no se puede mantener.
        else if (Input.GetMouseButtonDown(0) && Time.time > nextFire && !equipedWeapon.canMaintainFire)
        {
            nextFire = Time.time + equipedWeapon.fireRate;
            equipedWeapon.Shooting = true;

            //Shooting
            if (equipedWeapon.type == Weapon.WeaponType.Lanzagranadas)
                equipedWeapon.ShootGrenade(GetMousePosInWorld());
            else if (equipedWeapon.type == Weapon.WeaponType.Revolver)
                equipedWeapon.ShootRevolver(fireSpawn.position, (fireSpawn.position - transform.position).normalized, this);
            else     
                equipedWeapon.Shoot(fireSpawn.position, (fireSpawn.position - transform.position).normalized);
        }
        //Quan deixes de disparar
        if (Input.GetMouseButtonUp(0) && equipedWeapon.Shooting)
        {
            equipedWeapon.Shooting = false;
            if (exhaustedMetralleta) exhaustedMetralleta = false;
        }
    }

    void LookAt()
    {
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {

        }
    }

    void MetralletaRoutine()
    {
        if (!equipedWeapon.Shooting)
        {
            equipedWeapon.fireRate -= Time.deltaTime / 8; //lo que accelera cada segundo
            equipedWeapon.fireRate = Mathf.Clamp(equipedWeapon.fireRate, 0.05f, 0.8f);
        }
        else
        {            
            metralletaContador += 0.0005f;
            equipedWeapon.fireRate *= Mathf.Pow(1.05f, metralletaContador);
            equipedWeapon.fireRate = Mathf.Clamp(equipedWeapon.fireRate, 0.05f, 0.8f);
            if (Mathf.Approximately(equipedWeapon.fireRate, 0.8f))
            {
                exhaustedMetralleta = true;
            }
        }
    }

    Vector3 GetMousePosInWorld()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }

    public void StartRevolverWait(float t)
    {
        StartCoroutine(RevolverWait(t));
    }
    IEnumerator RevolverWait (float t)
    {
        yield return new WaitForSeconds(t);
        equipedWeapon.ResetRevolver();
    }

    void ChangeWeapon ()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            weaponIndex = 0;
            equipedWeapon = unlockedWeapons[weaponIndex];
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            weaponIndex = 1;
            equipedWeapon = unlockedWeapons[weaponIndex];
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            weaponIndex = 2;
            equipedWeapon = unlockedWeapons[weaponIndex];
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            weaponIndex = 3;
            equipedWeapon = unlockedWeapons[weaponIndex];
        }
        if (Input.GetKey(KeyCode.Alpha5))
        {
            weaponIndex = 4;
            equipedWeapon = unlockedWeapons[weaponIndex];
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            weaponIndex = (weaponIndex + 1) % unlockedWeapons.Count;
            equipedWeapon = unlockedWeapons[weaponIndex];
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            weaponIndex--;
            if (weaponIndex == 0)
                weaponIndex = 4;

            equipedWeapon = unlockedWeapons[weaponIndex];

        }

        
    }
    
    public void AddNextWeapon()
    {
        unlockedWeapons.Add(allWeapons[unlockedWeapons.Count]);
    }

    /*bool Move()
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

    }*/

    /*void Aim()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        aimDirection = mousePos - transform.position;
        aimDirection = Vector3.Normalize(aimDirection)*firePointDistance;

        fireSpawn.transform.position = transform.position + aimDirection;        

    }*/
}
