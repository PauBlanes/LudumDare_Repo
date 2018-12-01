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
    int enemiesXround=5;
    float timeBetweenEnemies=1;
    float timeBetweenRounds=5;
    int enemyMultiplayer = 5;

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
                int aux = Random.Range(0, SpawnPoints.Length);
                Instantiate(EnemyPrefabs[0], SpawnPoints[aux].transform.position, Quaternion.identity);
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
