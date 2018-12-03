using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoDrop : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(WaitAndDie());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator WaitAndDie()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
