﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    public float speed;
    public float damage;

    public Vector3 direction;

    private float lifeCounter;
    private float lifeTime = 2;

    public bool penetrate;

	// Use this for initialization
	void Start () {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, -direction);
    }
	
	// Update is called once per frame
	void Update () {
        //Moure
        transform.position += direction * Time.deltaTime * speed;
        
        //Destruir despres de X temps
        lifeCounter += Time.deltaTime;
        if (lifeCounter >= lifeTime)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
        
    }
}
