using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour {

    public float damage;
    public float dmgRadius;
    public float buffRadius;
    public float lifeTime; //Segurament el temps d'animació

    private List<GameObject> enemiesInDmgRange = new List<GameObject>();
    private List<GameObject> enemiesInBuffRange = new List<GameObject>();

    LineRenderer line;
    public int segments = 50;    

    // Use this for initialization
    void Start () {

        StartCoroutine(WaitAndDestroy());

        foreach (GameObject e in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            if ((e.transform.position - transform.position).magnitude < dmgRadius)
                enemiesInDmgRange.Add(e);
            else if ((e.transform.position - transform.position).magnitude < buffRadius)
                enemiesInBuffRange.Add(e);
        }        

        foreach (GameObject e in enemiesInDmgRange)
        {
            e.GetComponent<Enemy>().Health -= damage;
        }
        foreach (GameObject e in enemiesInBuffRange)
        {
            e.GetComponent<Enemy>().Buff();
        }

        //Pintar linia daño
        line = gameObject.GetComponent<LineRenderer>();
        line.positionCount = (segments + 1);
        line.useWorldSpace = false;
        CreatePoints(dmgRadius);
    }
	
	IEnumerator WaitAndDestroy ()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }

    void CreatePoints(float radius)
    {
        float x;
        float y;        

        float angle = 20f;

        for (int i = 0; i < (segments + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            y = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;

            line.SetPosition(i, new Vector3(x, y, 0));

            angle += (360f / segments);
        }
        
    }
}
