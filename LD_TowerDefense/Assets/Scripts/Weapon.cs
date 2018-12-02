using UnityEngine;

[System.Serializable]
public class Weapon {

    public enum WeaponType { Pistola, Metralleta, Revolver, Lanzagranadas, Francotirador};

    private bool shooting; //pq no es mostri al inspector pero poder-hi accedir
    public bool Shooting {
        get { return shooting; }
        set { shooting = value; }
    }
    public WeaponType type;
    public float fireRate;
    public GameObject bullet;

    public bool canMaintainFire; //per fer si pots mantenir apretat per disparar

    public void Shoot (Vector3 spawnPoint, Vector3 direction)
    {        
        GameObject b = GameObject.Instantiate(bullet, spawnPoint, Quaternion.identity);
        b.GetComponent<bullet>().direction = direction;
        if (type == WeaponType.Francotirador)
            b.GetComponent<bullet>().penetrate = true;
    }
}
