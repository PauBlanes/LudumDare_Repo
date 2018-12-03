using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{

    public int Score = 0;

    public GameObject[] SpawnPoints;

    public GameObject[] EnemyPrefabs;

    public int Round = 1;

    public GameObject ammoIcon;
    
    //NO TOCAR
    public int enemiesXround = 5;
    float timeBetweenEnemies = 0.5f;
    float timeBetweenRounds = 7;
    int enemyMultiplayer = 35;

    public Text WaveText;
    //
    int numNorm, numFast, numTank, numSpec;


    float timeSpawn = 0;
    float timeRest;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
        timeRest = timeBetweenRounds;
        Round = 1;
        numNorm = 17 + (2 * (Round - 5));
        numFast = 15 + (3 * (Round - 5));
        numTank = 8 + Mathf.FloorToInt((Round - 5) / 3);
        numSpec = 14 + (1 * (Round - 5));
        enemiesXround = numFast + numNorm + numTank + numSpec;

    }

    // Update is called once per frame
    void Update()
    {
        Horde();
    }

    void Horde()
    {
        if (enemiesXround > 0)
        {
            timeSpawn -= Time.deltaTime;
            if (timeSpawn <= 0)
            {
                int aux2 = Random.Range(0, 100);
                int aux = Random.Range(0, EnemyPrefabs.Length);
                int zone = 0;

                if (aux2 < 15)
                {
                    zone = 0;
                }
                else if (aux2 < 30)
                {
                    zone = 1;
                }
                else if (aux2 < 60)
                {
                    zone = 2;
                }
                else if (aux2 < 100)
                {
                    zone = 3;
                }

                if (aux == 0 && numNorm > 0)
                {
                    Instantiate(EnemyPrefabs[aux], SpawnPoints[zone].transform.position, Quaternion.identity);
                    numNorm--;
                    enemiesXround--;
                    timeSpawn = timeBetweenEnemies;

                }
                else if (aux == 1 && numFast > 0)
                {
                    Instantiate(EnemyPrefabs[aux], SpawnPoints[zone].transform.position, Quaternion.identity);
                    numFast--;
                    enemiesXround--;
                    timeSpawn = timeBetweenEnemies;

                }
                else if (aux == 2 && numTank > 0)
                {
                    Instantiate(EnemyPrefabs[aux], SpawnPoints[zone].transform.position, Quaternion.identity);
                    numTank--;
                    enemiesXround--;
                    timeSpawn = timeBetweenEnemies;

                }
                else if (aux == 3 && numSpec > 0)
                {
                    Instantiate(EnemyPrefabs[aux], SpawnPoints[zone].transform.position, Quaternion.identity);
                    numSpec--;
                    enemiesXround--;
                    timeSpawn = timeBetweenEnemies;

                }

            }
        }
        else
        {
            timeRest -= Time.deltaTime;
            if (timeRest <= 0)
            {
                Round++;
                timeRest = timeBetweenRounds;
                numNorm = 17 + (2 * (Round - 5));
                numFast = 2 + (3 * (Round - 5));
                numTank = 8 + Mathf.FloorToInt((Round - 5) / 3);
                numSpec = 15 + (1 * (Round - 5));
                enemiesXround = numFast + numNorm + numTank + numSpec;
                WaveText.text = "ROUND " + Round.ToString();
                this.GetComponent<AudioSource>().Play();
            }
        }
    }

    public void DropAmmo(Vector3 p)
    {
        Instantiate(ammoIcon, p, Quaternion.identity);
    }
}
