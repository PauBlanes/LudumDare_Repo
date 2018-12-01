using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour {


    public GameObject[] SpawnPoints;

    public GameObject[] EnemyPrefabs;

    public int Round=0;

    public Text GameOverText;
    //NO TOCAR
    int enemiesXround=50;
    float timeBetweenEnemies=0.2f;
    float timeBetweenRounds=5;
    int enemyMultiplayer = 35;

    float timeSpawn=0;
    float timeRest;

	// Use this for initialization
	void Start () {
        timeRest = timeBetweenRounds;
	}
	
	// Update is called once per frame
	void Update () {

        if (enemiesXround > 0)
        {
            timeSpawn -= Time.deltaTime;
            if (timeSpawn <= 0)
            {
                int aux = Random.Range(0, 100);
                int aux2 = Random.Range(0,10);
                int type=0;
                if (aux2 < 1)
                    type = 3;
                else if (aux2 < 3)
                    type = 2;
                else if (aux2 < 5)
                    type = 1;
                else if (aux2 < 10)
                    type = 0;

                if (aux < 15)
                {
                    Instantiate(EnemyPrefabs[type], SpawnPoints[0].transform.position, Quaternion.identity);
                }
                else if (aux < 30)
                {
                    Instantiate(EnemyPrefabs[type], SpawnPoints[1].transform.position, Quaternion.identity);
                }
                else if (aux < 60)
                {
                    Instantiate(EnemyPrefabs[type], SpawnPoints[2].transform.position, Quaternion.identity);
                }
                else if (aux < 100)
                {
                    Instantiate(EnemyPrefabs[type], SpawnPoints[3].transform.position, Quaternion.identity);
                }

                enemiesXround--;
                timeSpawn = timeBetweenEnemies;
            }
        }
        else
        {
            timeRest -= Time.deltaTime;
            if (timeRest <= 0)
            {
                Round++;
                enemiesXround = Round*enemyMultiplayer;
                timeRest = timeBetweenRounds;
            }
        }
        
	}
    public void GameOver()
    {
        GameOverText.gameObject.SetActive(true);
    }
}
