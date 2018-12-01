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

                if(aux < 15)
                {
                    Instantiate(EnemyPrefabs[0], SpawnPoints[0].transform.position, Quaternion.identity);
                }
                else if (aux < 30)
                {
                    Instantiate(EnemyPrefabs[0], SpawnPoints[1].transform.position, Quaternion.identity);
                }
                else if (aux < 60)
                {
                    Instantiate(EnemyPrefabs[0], SpawnPoints[2].transform.position, Quaternion.identity);
                }
                else if (aux < 100)
                {
                    Instantiate(EnemyPrefabs[0], SpawnPoints[3].transform.position, Quaternion.identity);
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
