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

    public bool removed;

    //per fer si pots mantenir apretat per disparar
    public bool canMaintainFire;

    //municion
    public int ammo;

    //Revolver
    private int revolverMaxAmmo = 6;    
    private float rechargeTime = 5;
    private int revolverCountAmmo = 6;
    
    public void Shoot (Vector3 spawnPoint, Vector3 direction)
    {
        if (ammo > 0 || type == WeaponType.Pistola)
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
        if (revolverCountAmmo > 0)
        {            
            Shoot(spawnPoint, direction);
            revolverCountAmmo--;
            GameObject.FindGameObjectWithTag("Base").GetComponent<Base>().AddHealth(-15);
        }
        else if (revolverCountAmmo == 0)
        {            
            pC.StartRevolverWait(rechargeTime);
            revolverCountAmmo++;
        }
    }
    
    public void ResetRevolver()
    {
        int newBullets = Mathf.Clamp(ammo - revolverMaxAmmo, 0, 6);
        ammo -= newBullets;
        revolverCountAmmo = newBullets;
    }
    
    public int GetRevolverAmmo()
    {
        return revolverCountAmmo;
    }
    
}
