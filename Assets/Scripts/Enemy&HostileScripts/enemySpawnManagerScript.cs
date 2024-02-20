using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManagerScript : MonoBehaviour
{
    // Public variables
    public GameObject[] enemyPrefab;
    public Transform[] enemySpawnPoints;
    public int initialWave = 5;
    public int addEnemyPerWave;
    public int waveBeforePause;
    public float enemySpawnInterval;
    public float waveSpawnInterval;
    public bool shouldSpawn = true;

    private int currentWave = 0;

    void Update()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        while (shouldSpawn)
        {
            yield return new WaitForSeconds(waveSpawnInterval);

            // Check if there are no enemies in the scene
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                Debug.Log("Starting Wave " + (currentWave + 1));
                for (int i = 0; i < initialWave + (currentWave * addEnemyPerWave); i++)
                {
                    // Randomly select a spawn point
                    Transform spawnPoint = enemySpawnPoints[Random.Range(0, enemySpawnPoints.Length)];
                    Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)], spawnPoint.position, spawnPoint.rotation);
                    Debug.Log("Total Enemies Spawned in Wave " + (currentWave + 1) + ": " + (initialWave + (currentWave * addEnemyPerWave)));
                    yield return new WaitForSeconds(enemySpawnInterval);
                }

                currentWave++;

                // Check if it's time to pause
                if (currentWave % waveBeforePause == 0)
                {
                    shouldSpawn = false;
                }
            }
        }
    }

    public void StartSpawning()
    {
        if (shouldSpawn)
        {
            StartCoroutine(SpawnWaves());
        }
       
    }
}
