using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {
    public int Score = 0;

    public int ronda = 1;

    public GameObject[] SpawnPoints;

    public GameObject[] EnemyPrefabs;

    public int Round = 0;
    public int wave = 0;

    public Image[] popUps;
    public Text GameOverText;
    //NO TOCAR
    int enemiesXround=5;
    float timeBetweenEnemies = 0.5f;
    float timeBetweenRounds = 7;
    int enemyMultiplayer = 35;

    public bool tutorial=true;

    public Text WaveText;
    //
    int numNorm, numFast, numTank, numSpec;


    float timeSpawn = 0;
    float timeRest;

    // Use this for initialization
    void Start()
    {
        timeRest = timeBetweenRounds;
        Round = 0;
        wave = 0;
        popUps[0].gameObject.SetActive(true);
        Time.timeScale = 0;


        /*numNorm = 17 + (2 * (Round - 5));
        numFast = 2 + (3 * (Round - 5));
        numTank = 8 + Mathf.FloorToInt((Round - 5) / 3);
        numSpec = 15 + (1 * (Round - 5));
        enemiesXround = numFast + numNorm + numTank + numSpec;*/

    }

    // Update is called once per frame
    void Update()
    {
        if (Round < 5) { Tuto(); }
        else { Horde(); }

    }
    public void GameOver()
    {
        GameOverText.gameObject.SetActive(true);
    }

    void Tuto()
    {



        //Wave 1
        if (Round == 0 && wave == 0)//ROUND 1
        {
            if (enemiesXround > 0)
            {
                timeSpawn -= Time.deltaTime;
                if (timeSpawn <= 0)
                {
                    Instantiate(EnemyPrefabs[0], SpawnPoints[2].transform.position, Quaternion.identity);
                    enemiesXround--;
                    timeSpawn = timeBetweenEnemies;
                }
            }
            else
            {
                timeRest -= Time.deltaTime;
                if (timeRest < 0)
                {
                    popUps[1].gameObject.SetActive(true);
                    Time.timeScale = 0;
                    wave++;
                    ronda++;
                    WaveText.text = "WAVE " + (ronda).ToString();
                    enemiesXround = 7;
                    timeRest = timeBetweenRounds;
                }
            }

        }
        else if (Round == 0 && wave == 1) //ROUND 2
        {
            if (enemiesXround > 0)
            {
                timeSpawn -= Time.deltaTime;
                if (timeSpawn <= 0)
                {
                    if (enemiesXround > 2)
                    {
                        Instantiate(EnemyPrefabs[0], SpawnPoints[2].transform.position, Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(EnemyPrefabs[1], SpawnPoints[2].transform.position, Quaternion.identity);
                    }

                    enemiesXround--;
                    timeSpawn = timeBetweenEnemies;
                }
            }
            else
            {
                timeRest -= Time.deltaTime;
                if (timeRest < 0)
                {
                    wave++;
                    ronda++;
                    WaveText.text = "WAVE " + (ronda).ToString();
                    enemiesXround = 10;
                    timeRest = timeBetweenRounds;
                }
            }
        }
        else if (Round == 0 && wave == 2) //ROUND 3
        {
            if (enemiesXround > 0)
            {
                timeSpawn -= Time.deltaTime;
                if (timeSpawn <= 0)
                {
                    if (enemiesXround > 5)
                    {
                        Instantiate(EnemyPrefabs[1], SpawnPoints[2].transform.position, Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(EnemyPrefabs[0], SpawnPoints[2].transform.position, Quaternion.identity);
                    }

                    enemiesXround--;
                    timeSpawn = timeBetweenEnemies;
                }
            }
            else
            {
                timeRest -= Time.deltaTime;
                if (timeRest < 0)
                {
                    popUps[2].gameObject.SetActive(true);
                    Time.timeScale = 0;
                    wave = 0;
                    Round++;
                    ronda++;
                    WaveText.text = "WAVE " + (ronda).ToString();
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().AddNextWeapon();
                    enemiesXround = 10;
                    timeRest = timeBetweenRounds;
                    numNorm = 7;
                    numFast = 3;
                }
            }
        }

        //Wave 2
        else if (Round == 1 && wave == 0) //ROUND 1
        {
            if (enemiesXround > 0)
            {
                timeSpawn -= Time.deltaTime;
                if (timeSpawn <= 0)
                {
                    int aux = Random.Range(0, 2);
                    int aux2 = Random.Range(2, 4);

                    if (aux == 0 && numNorm > 0)
                    {
                        Instantiate(EnemyPrefabs[aux], SpawnPoints[aux2].transform.position, Quaternion.identity);
                        numNorm--;
                        enemiesXround--;
                        timeSpawn = timeBetweenEnemies;
                    }
                    else if (aux == 1 && numNorm > 0)
                    {
                        Instantiate(EnemyPrefabs[aux], SpawnPoints[aux2].transform.position, Quaternion.identity);
                        numFast--;
                        enemiesXround--;
                        timeSpawn = timeBetweenEnemies;
                    }

                }
            }
            else
            {
                timeRest -= Time.deltaTime;
                if (timeRest < 0)
                {
                    wave++;
                    ronda++;
                    WaveText.text = "WAVE " + (ronda).ToString();
                    timeRest = timeBetweenRounds;
                    numNorm = 9;
                    numFast = 6;
                    enemiesXround = numFast + numNorm;
                }
            }
        }
        else if (Round == 1 && wave == 1) //ROUND 2
        {
            if (enemiesXround > 0)
            {
                timeSpawn -= Time.deltaTime;
                if (timeSpawn <= 0)
                {
                    int aux = Random.Range(0, 2);
                    int aux2 = Random.Range(2, 4);

                    if (aux == 0 && numNorm > 0)
                    {
                        Instantiate(EnemyPrefabs[aux], SpawnPoints[aux2].transform.position, Quaternion.identity);
                        numNorm--;
                        enemiesXround--;
                        timeSpawn = timeBetweenEnemies;
                    }
                    else if (aux == 1 && numFast > 0)
                    {
                        Instantiate(EnemyPrefabs[aux], SpawnPoints[aux2].transform.position, Quaternion.identity);
                        numFast--;
                        enemiesXround--;
                        timeSpawn = timeBetweenEnemies;
                    }

                }
            }
            else
            {
                timeRest -= Time.deltaTime;
                if (timeRest < 0)
                {
                    popUps[3].gameObject.SetActive(true);
                    Time.timeScale = 0;
                    wave++;
                    ronda++;
                    WaveText.text = "WAVE " + (ronda).ToString();
                    timeRest = timeBetweenRounds;
                    numNorm = 7;
                    numFast = 7;
                    numTank = 1;
                    enemiesXround = numFast + numNorm + numTank;
                }
            }
        }
        else if (Round == 1 && wave == 2) //ROUND 3
        {
            if (enemiesXround > 0)
            {
                timeSpawn -= Time.deltaTime;
                if (timeSpawn <= 0)
                {
                    int aux = Random.Range(0, 2);
                    int aux2 = Random.Range(2, 4);

                    if (aux == 0 && numNorm > 0)
                    {
                        Instantiate(EnemyPrefabs[aux], SpawnPoints[aux2].transform.position, Quaternion.identity);
                        numNorm--;
                        enemiesXround--;
                        timeSpawn = timeBetweenEnemies;
                    }
                    else if (aux == 1 && numFast > 0)
                    {
                        Instantiate(EnemyPrefabs[aux], SpawnPoints[aux2].transform.position, Quaternion.identity);
                        numFast--;
                        enemiesXround--;
                        timeSpawn = timeBetweenEnemies;
                    }
                    if (enemiesXround == 1)
                    {
                        Instantiate(EnemyPrefabs[2], SpawnPoints[2].transform.position, Quaternion.identity);
                        numTank--;
                        enemiesXround--;
                        timeSpawn = timeBetweenEnemies;
                    }

                }
            }
            else
            {
                timeRest -= Time.deltaTime;
                if (timeRest < 0)
                {
                    wave++;
                    ronda++;
                    WaveText.text = "WAVE " + (ronda).ToString();
                    timeRest = timeBetweenRounds;
                    numNorm = 10;
                    numFast = 8;
                    numTank = 2;
                    enemiesXround = numFast + numNorm + numTank;
                }
            }
        }
        else if (Round == 1 && wave == 3) //ROUND 4
        {
            if (enemiesXround > 0)
            {
                timeSpawn -= Time.deltaTime;
                if (timeSpawn <= 0)
                {
                    int aux = Random.Range(0, 3);
                    int aux2 = Random.Range(2, 4);

                    if (aux == 0 && numNorm > 0)
                    {
                        Instantiate(EnemyPrefabs[aux], SpawnPoints[aux2].transform.position, Quaternion.identity);
                        numNorm--;
                        enemiesXround--;
                        timeSpawn = timeBetweenEnemies;
                    }
                    else if (aux == 1 && numFast > 0)
                    {
                        Instantiate(EnemyPrefabs[aux], SpawnPoints[aux2].transform.position, Quaternion.identity);
                        numFast--;
                        enemiesXround--;
                        timeSpawn = timeBetweenEnemies;
                    }
                    else if (aux == 1 && numTank > 0)
                    {
                        Instantiate(EnemyPrefabs[aux], SpawnPoints[aux2].transform.position, Quaternion.identity);
                        numTank--;
                        enemiesXround--;
                        timeSpawn = timeBetweenEnemies;
                    }

                }
            }
            else
            {
                timeRest -= Time.deltaTime;
                if (timeRest < 0)
                {
                    popUps[4].gameObject.SetActive(true);
                    Time.timeScale = 0;
                    wave = 0;
                    Round++;
                    ronda++;
                    WaveText.text = "WAVE " + (ronda).ToString();
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().AddNextWeapon();
                    timeRest = timeBetweenRounds;
                    numNorm = 9;
                    numFast = 9;
                    numTank = 1;
                    enemiesXround = numFast + numNorm + numTank;
                }
            }
        }

        //Wave 3
        else if (Round == 2 && wave == 0) //ROUND 1
        {
            if (enemiesXround > 0)
            {
                timeSpawn -= Time.deltaTime;
                if (timeSpawn <= 0)
                {
                    int aux = Random.Range(0, 3);
                    int aux2 = Random.Range(1, 4);

                    if (aux == 0 && numNorm > 0)
                    {
                        Instantiate(EnemyPrefabs[aux], SpawnPoints[aux2].transform.position, Quaternion.identity);
                        numNorm--;
                        enemiesXround--;
                        timeSpawn = timeBetweenEnemies;
                    }
                    else if (aux == 1 && numFast > 0)
                    {
                        Instantiate(EnemyPrefabs[aux], SpawnPoints[aux2].transform.position, Quaternion.identity);
                        numFast--;
                        enemiesXround--;
                        timeSpawn = timeBetweenEnemies;
                    }
                    else if (aux == 1 && numTank > 0)
                    {
                        Instantiate(EnemyPrefabs[aux], SpawnPoints[aux2].transform.position, Quaternion.identity);
                        numTank--;
                        enemiesXround--;
                        timeSpawn = timeBetweenEnemies;
                    }

                }
            }
            else
            {
                timeRest -= Time.deltaTime;
                if (timeRest < 0)
                {
                    wave++;
                    ronda++;
                    WaveText.text = "WAVE " + (ronda).ToString();
                    timeRest = timeBetweenRounds;
                    numNorm = 10;
                    numFast = 13;
                    numTank = 2;
                    enemiesXround = numFast + numNorm + numTank;
                }
            }
        }
        else if (Round == 2 && wave == 1) //ROUND 2
        {
            if (enemiesXround > 0)
            {
                timeSpawn -= Time.deltaTime;
                if (timeSpawn <= 0)
                {
                    int aux = Random.Range(0, 3);
                    int aux2 = Random.Range(1, 4);

                    if (aux == 0 && numNorm > 0)
                    {
                        Instantiate(EnemyPrefabs[aux], SpawnPoints[aux2].transform.position, Quaternion.identity);
                        numNorm--;
                        enemiesXround--;
                        timeSpawn = timeBetweenEnemies;
                    }
                    else if (aux == 1 && numFast > 0)
                    {
                        Instantiate(EnemyPrefabs[aux], SpawnPoints[aux2].transform.position, Quaternion.identity);
                        numFast--;
                        enemiesXround--;
                        timeSpawn = timeBetweenEnemies;
                    }
                    else if (aux == 1 && numTank > 0)
                    {
                        Instantiate(EnemyPrefabs[aux], SpawnPoints[aux2].transform.position, Quaternion.identity);
                        numTank--;
                        enemiesXround--;
                        timeSpawn = timeBetweenEnemies;
                    }

                }
            }
            else
            {
                timeRest -= Time.deltaTime;
                if (timeRest < 0)
                {
                    wave++;
                    ronda++;
                    WaveText.text = "WAVE " + (ronda).ToString();
                    timeRest = timeBetweenRounds;
                    numNorm = 10;
                    numFast = 14;
                    numTank = 3;
                    enemiesXround = numFast + numNorm + numTank;
                }
            }
        }
        else if (Round == 2 && wave == 2) //ROUND 3
        {
            if (enemiesXround > 0)
            {
                timeSpawn -= Time.deltaTime;
                if (timeSpawn <= 0)
                {
                    int aux = Random.Range(0, 3);
                    int aux2 = Random.Range(1, 4);

                    if (aux == 0 && numNorm > 0)
                    {
                        Instantiate(EnemyPrefabs[aux], SpawnPoints[aux2].transform.position, Quaternion.identity);
                        numNorm--;
                        enemiesXround--;
                        timeSpawn = timeBetweenEnemies;
                    }
                    else if (aux == 1 && numFast > 0)
                    {
                        Instantiate(EnemyPrefabs[aux], SpawnPoints[aux2].transform.position, Quaternion.identity);
                        numFast--;
                        enemiesXround--;
                        timeSpawn = timeBetweenEnemies;
                    }
                    else if (aux == 1 && numTank > 0)
                    {
                        Instantiate(EnemyPrefabs[aux], SpawnPoints[aux2].transform.position, Quaternion.identity);
                        numTank--;
                        enemiesXround--;
                        timeSpawn = timeBetweenEnemies;
                    }

                }
            }
            else
            {
                timeRest -= Time.deltaTime;
                if (timeRest < 0)
                {
                    wave++;
                    ronda++;
                    WaveText.text = "WAVE " + (ronda).ToString();
                    timeRest = timeBetweenRounds;
                    numNorm = 15;
                    numFast = 12;
                    numTank = 3;
                    enemiesXround = numFast + numNorm + numTank;
                }
            }
        }
        else if (Round == 2 && wave == 3) //ROUND 4
        {
            if (enemiesXround > 0)
            {
                timeSpawn -= Time.deltaTime;
                if (timeSpawn <= 0)
                {
                    int aux = Random.Range(0, 3);
                    int aux2 = Random.Range(1, 4);

                    if (aux == 0 && numNorm > 0)
                    {
                        Instantiate(EnemyPrefabs[aux], SpawnPoints[aux2].transform.position, Quaternion.identity);
                        numNorm--;
                        enemiesXround--;
                        timeSpawn = timeBetweenEnemies;
                    }
                    else if (aux == 1 && numFast > 0)
                    {
                        Instantiate(EnemyPrefabs[aux], SpawnPoints[aux2].transform.position, Quaternion.identity);
                        numFast--;
                        enemiesXround--;
                        timeSpawn = timeBetweenEnemies;
                    }
                    else if (aux == 1 && numTank > 0)
                    {
                        Instantiate(EnemyPrefabs[aux], SpawnPoints[aux2].transform.position, Quaternion.identity);
                        numTank--;
                        enemiesXround--;
                        timeSpawn = timeBetweenEnemies;
                    }

                }
            }
            else
            {
                
                timeRest -= Time.deltaTime;
                if (timeRest < 0)
                {
                    popUps[5].gameObject.SetActive(true);
                    Time.timeScale = 0;
                    Round++;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().AddNextWeapon();
                    wave = 0;
                    ronda++;
                    WaveText.text = "WAVE " + (ronda).ToString();
                    timeRest = timeBetweenRounds;
                    numNorm = 15;
                    numFast = 12;
                    numTank = 3;
                    numSpec = 6;
                    enemiesXround = numFast + numNorm + numTank + numSpec;
                }
            }
        }

        //Wave 4
        else if (Round == 3 && wave == 0) //ROUND 1
        {
            if (enemiesXround > 0)
            {
                timeSpawn -= Time.deltaTime;
                if (timeSpawn <= 0)
                {
                    int aux = Random.Range(0, 100);
                    int aux2 = Random.Range(0, EnemyPrefabs.Length);
                    int zone = 0;

                    if (aux < 15)
                    {
                        zone = 0;
                    }
                    else if (aux < 30)
                    {
                        zone = 1;
                    }
                    else if (aux < 60)
                    {
                        zone = 2;
                    }
                    else if (aux < 100)
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
                if (timeRest < 0)
                {
                    wave++;
                    ronda++;
                    WaveText.text = "WAVE " + (ronda).ToString();
                    timeRest = timeBetweenRounds;
                    numNorm = 10;
                    numFast = 10;
                    numTank = 2;
                    numSpec = 8;
                    enemiesXround = numFast + numNorm + numTank + numSpec;
                }
            }
        }
        else if (Round == 3 && wave == 1) //ROUND 2
        {
            if (enemiesXround > 0)
            {
                timeSpawn -= Time.deltaTime;
                if (timeSpawn <= 0)
                {
                    int aux = Random.Range(0, 100);
                    int aux2 = Random.Range(0, EnemyPrefabs.Length);
                    int zone = 0;

                    if (aux < 15)
                    {
                        zone = 0;
                    }
                    else if (aux < 30)
                    {
                        zone = 1;
                    }
                    else if (aux < 60)
                    {
                        zone = 2;
                    }
                    else if (aux < 100)
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
                if (timeRest < 0)
                {
                    wave++;
                    ronda++;
                    WaveText.text = "WAVE " + (ronda).ToString();
                    timeRest = timeBetweenRounds;
                    numNorm = 10;
                    numFast = 13;
                    numTank = 3;
                    numSpec = 10;
                    enemiesXround = numFast + numNorm + numTank + numSpec;
                }
            }
        }
        else if (Round == 3 && wave == 2) //ROUND 3
        {
            if (enemiesXround > 0)
            {
                timeSpawn -= Time.deltaTime;
                if (timeSpawn <= 0)
                {
                    int aux = Random.Range(0, 100);
                    int aux2 = Random.Range(0, EnemyPrefabs.Length);
                    int zone = 0;

                    if (aux < 15)
                    {
                        zone = 0;
                    }
                    else if (aux < 30)
                    {
                        zone = 1;
                    }
                    else if (aux < 60)
                    {
                        zone = 2;
                    }
                    else if (aux < 100)
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
                if (timeRest < 0)
                {
                    wave++;
                    ronda++;
                    WaveText.text = "WAVE " + (ronda).ToString();
                    timeRest = timeBetweenRounds;
                    numNorm = 12;
                    numFast = 15;
                    numTank = 2;
                    numSpec = 12;
                    enemiesXround = numFast + numNorm + numTank + numSpec;
                }
            }
        }
        else if (Round == 3 && wave == 3) //ROUND 4
        {
            if (enemiesXround > 0)
            {
                timeSpawn -= Time.deltaTime;
                if (timeSpawn <= 0)
                {
                    int aux = Random.Range(0, 100);
                    int aux2 = Random.Range(0, EnemyPrefabs.Length);
                    int zone = 0;

                    if (aux < 15)
                    {
                        zone = 0;
                    }
                    else if (aux < 30)
                    {
                        zone = 1;
                    }
                    else if (aux < 60)
                    {
                        zone = 2;
                    }
                    else if (aux < 100)
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
                if (timeRest < 0)
                {
                    popUps[7].gameObject.SetActive(true);
                    Time.timeScale = 0;
                    Round++;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().AddNextWeapon();
                    wave = 0;
                    ronda++;
                    WaveText.text = "WAVE " + (ronda).ToString();
                    timeRest = timeBetweenRounds;
                    numNorm = 13;
                    numFast = 12;
                    numTank = 3;
                    numSpec = 12;
                    enemiesXround = numFast + numNorm + numTank + numSpec;
                }
            }
        }

        //Wave 5
        else if (Round == 4 && wave == 0) //ROUND 1
        {
            if (enemiesXround > 0)
            {
                timeSpawn -= Time.deltaTime;
                if (timeSpawn <= 0)
                {
                    int aux = Random.Range(0, 100);
                    int aux2 = Random.Range(0, EnemyPrefabs.Length);
                    int zone = 0;

                    if (aux < 15)
                    {
                        zone = 0;
                    }
                    else if (aux < 30)
                    {
                        zone = 1;
                    }
                    else if (aux < 60)
                    {
                        zone = 2;
                    }
                    else if (aux < 100)
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
                if (timeRest < 0)
                {
                    wave++;
                    ronda++;
                    WaveText.text = "WAVE " + (ronda).ToString();
                    timeRest = timeBetweenRounds;
                    numNorm = 13;
                    numFast = 12;
                    numTank = 8;
                    numSpec = 12;
                    enemiesXround = numFast + numNorm + numTank + numSpec;
                }
            }
        }
        else if (Round == 4 && wave == 1) //ROUND 2
        {
            if (enemiesXround > 0)
            {
                timeSpawn -= Time.deltaTime;
                if (timeSpawn <= 0)
                {
                    int aux = Random.Range(0, 100);
                    int aux2 = Random.Range(0, EnemyPrefabs.Length);
                    int zone = 0;

                    if (aux < 15)
                    {
                        zone = 0;
                    }
                    else if (aux < 30)
                    {
                        zone = 1;
                    }
                    else if (aux < 60)
                    {
                        zone = 2;
                    }
                    else if (aux < 100)
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
                if (timeRest < 0)
                {
                    wave++;
                    ronda++;
                    WaveText.text = "WAVE " + (ronda).ToString();
                    timeRest = timeBetweenRounds;
                    numNorm = 15;
                    numFast = 15;
                    numTank = 5;
                    numSpec = 15;
                    enemiesXround = numFast + numNorm + numTank + numSpec;
                }
            }
        }
        else if (Round == 4 && wave == 2) //ROUND 3
        {
            if (enemiesXround > 0)
            {
                timeSpawn -= Time.deltaTime;
                if (timeSpawn <= 0)
                {
                    int aux = Random.Range(0, 100);
                    int aux2 = Random.Range(0, EnemyPrefabs.Length);
                    int zone = 0;

                    if (aux < 15)
                    {
                        zone = 0;
                    }
                    else if (aux < 30)
                    {
                        zone = 1;
                    }
                    else if (aux < 60)
                    {
                        zone = 2;
                    }
                    else if (aux < 100)
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
                if (timeRest < 0)
                {
                    wave++;
                    ronda++;
                    WaveText.text = "WAVE " + (ronda).ToString();
                    timeRest = timeBetweenRounds;
                    numNorm = 17;
                    numFast = 20;
                    numTank = 8;
                    numSpec = 15;
                    enemiesXround = numFast + numNorm + numTank + numSpec;
                }
            }
        }
        else if (Round == 4 && wave == 3) //ROUND 4
        {
            if (enemiesXround > 0)
            {
                timeSpawn -= Time.deltaTime;
                if (timeSpawn <= 0)
                {
                    int aux = Random.Range(0, 100);
                    int aux2 = Random.Range(0, 4);

                    if (aux == 0 && numNorm > 0)
                    {
                        Instantiate(EnemyPrefabs[aux], SpawnPoints[aux2].transform.position, Quaternion.identity);
                        numNorm--;
                        enemiesXround--;
                        timeSpawn = timeBetweenEnemies;
                    }
                    else if (aux == 1 && numFast > 0)
                    {
                        Instantiate(EnemyPrefabs[aux], SpawnPoints[aux2].transform.position, Quaternion.identity);
                        numFast--;
                        enemiesXround--;
                        timeSpawn = timeBetweenEnemies;
                    }
                    else if (aux == 2 && numTank > 0)
                    {
                        Instantiate(EnemyPrefabs[aux], SpawnPoints[aux2].transform.position, Quaternion.identity);
                        numTank--;
                        enemiesXround--;
                        timeSpawn = timeBetweenEnemies;
                    }
                    else if (aux == 3 && numSpec > 0)
                    {
                        Instantiate(EnemyPrefabs[aux], SpawnPoints[aux2].transform.position, Quaternion.identity);
                        numSpec--;
                        enemiesXround--;
                        timeSpawn = timeBetweenEnemies;
                    }

                }
            }
            else
            {
                timeRest -= Time.deltaTime;
                if (timeRest < 0)
                {
                    tutorial = false;
                    popUps[8].gameObject.SetActive(true);
                    Time.timeScale = 0;
                    Round++;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().AddNextWeapon();
                    wave = 0;
                    ronda++;
                    WaveText.text = "WAVE " + (ronda).ToString();
                    timeRest = timeBetweenRounds;
                    numNorm = 19;
                    numFast = 23;
                    numTank = 8;
                    numSpec = 16;
                    enemiesXround = numFast + numNorm + numTank + numSpec;
                }
            }
        }


    }

    void Horde()
    {
        if (enemiesXround > 0)
        {
            timeSpawn -= Time.deltaTime;
            if (timeSpawn <= 0)
            {
                int aux = Random.Range(0, 100);
                int aux2 = Random.Range(0, EnemyPrefabs.Length);
                int zone = 0;

                if (aux < 15)
                {
                    zone = 0;
                }
                else if (aux < 30)
                {
                    zone = 1;
                }
                else if (aux < 60)
                {
                    zone = 2;
                }
                else if (aux < 100)
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
                wave = 0;
                ronda++;
                WaveText.text = "WAVE " + (ronda).ToString();
                timeRest = timeBetweenRounds;
                numNorm = 17 + (2 * (Round - 5));
                numFast = 2 + (3 * (Round - 5));
                numTank = 8 + Mathf.FloorToInt((Round - 5) / 3);
                numSpec = 15 + (1 * (Round - 5));
                enemiesXround = numFast + numNorm + numTank + numSpec;
            }
        }
    }

}
