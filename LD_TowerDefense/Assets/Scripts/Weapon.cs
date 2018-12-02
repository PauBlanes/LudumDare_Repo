using UnityEngine;
using System.Collections;

[System.Serializable]
public class Weapon {

    public enum WeaponType { Pistola, Metralleta, Revolver, Lanzagranadas, Francotirador};

    private bool shooting; //pq no es mostri al inspector pero poder-hi accedir
    public bool Shooting {
        get { return shooting; }
        set { shooting = value; }
    }
    public float fireRate;

    public WeaponType type;   

    public GameObject bullet;

    //per fer si pots mantenir apretat per disparar
    public bool canMaintainFire;

    //municion
    public int ammo;

    //Revolver
    private int revolverMaxAmmo = 6;    
    private float rechargeTime = 5;
    private int revolverCountAmmo;


    public void Shoot (Vector3 spawnPoint, Vector3 direction)
    {
        if (ammo > 0)
        {
            GameObject b = GameObject.Instantiate(bullet, spawnPoint, Quaternion.identity);
            b.GetComponent<bullet>().direction = direction;

            ammo--;
        }                
    }

    public void ShootGrenade (Vector3 spawnPoint)
    {
        if (ammo > 0)
        {
            GameObject.Instantiate(bullet, spawnPoint, Quaternion.identity);

            ammo--;
        }       
    }
    public void ShootRevolver(Vector3 spawnPoint, Vector3 direction, PlayerController pC)
    {        
        if (revolverCountAmmo < revolverMaxAmmo)
        {            
            Shoot(spawnPoint, direction);
            revolverCountAmmo++;
            GameObject.FindGameObjectWithTag("Base").GetComponent<Base>().health -= 15;
        }
        else if (revolverCountAmmo == revolverMaxAmmo)
        {            
            pC.StartRevolverWait(rechargeTime);
            revolverCountAmmo++;
        }
    }
    
    public void ResetRevolver()
    {        
        revolverCountAmmo = 0;
    }
    
    public int GetRevolverAmmo()
    {
        return revolverCountAmmo;
    }
    
}
