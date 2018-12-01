using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

    public GameObject[] Nodes;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Enemy enemyscript = other.GetComponent<Enemy>();
            if (enemyscript.Target == this.gameObject || enemyscript.Target==null)
            {
                int aux = Random.Range(0, Nodes.Length);
                enemyscript.Target = Nodes[aux];
                enemyscript.setDir();
            }

        }
    }
}
