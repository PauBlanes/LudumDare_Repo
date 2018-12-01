﻿using UnityEngine;

[System.Serializable]
public class Weapon {

    public enum WeaponType { basic, machinegun};

    public WeaponType type;
    public float fireRate;
    public GameObject bullet;

    public void Shoot (Vector3 spawnPoint, Vector3 direction)
    {
        GameObject b = GameObject.Instantiate(bullet, spawnPoint, Quaternion.identity);
        b.GetComponent<bullet>().direction = direction;
    }
}
