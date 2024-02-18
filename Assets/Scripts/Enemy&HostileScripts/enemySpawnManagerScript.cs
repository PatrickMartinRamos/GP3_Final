using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// so sa enemySpawnManager sa scene doon tayo mag lalagay ng mga wave like ilang wave ba ilang enemy mag spawn
/// per wave then nag lagay din ng ShouldSpawn naka auto nato pag nag start baguhin nlng pag nag add
/// na tayo ng ibang step bago mag start ang game or kung mag spawn tayo ng boss or kung nasa shop si player
/// para ma pause ung wave 
/// 
/// tas edit nalng naten yung mga enemyprefab pag meron na tayong multiple enemy i randomize nlng
/// naten kung sino mag spawn 
/// 
/// next na gagwin dito is ung pag rotate ng wave like max wave naten is 15 waves tas pag na reach na ung 15 wave reset
/// naten ung wave pero after reset x2 na ung ilalabas na enemy per wave
/// </summary>


[System.Serializable]
public class Wave
{
    public GameObject enemyPrefab;
    public int enemyToSpawn;
    public float spawnInterval;
}

public class enemySpawnManagerScript : MonoBehaviour
{
    // Public variables
    public Transform[] enemySpawnPoints;
    public List<Wave> waves;
    //public float timeBetweenWaves = 5f;
    public int wavesBeforePause = 3; 

    public bool shouldSpawn = true;
    private int currentWave = 0;
    private int wavesSpawnedSincePause = 0;

    void Update()
    {
        // Check if there are any enemies present in the scene
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0)
        {
            // If no enemies are present, proceed to the next wave
            if (currentWave < waves.Count && shouldSpawn)
            {
                Debug.Log("Spawning Wave " + (currentWave + 1));
                StartCoroutine(SpawnWave(waves[currentWave]));

                currentWave++;
                wavesSpawnedSincePause++;

                if (wavesSpawnedSincePause >= wavesBeforePause)
                {
                    shouldSpawn = false;
                    wavesSpawnedSincePause = 0;
                }
            }
        }
    }

    IEnumerator SpawnWave(Wave wave)
    {
        for (int i = 0; i < wave.enemyToSpawn; i++)
        {
            SpawnEnemy(wave.enemyPrefab);
            yield return new WaitForSeconds(wave.spawnInterval); // Time between spawning each enemy in a wave
        }
    }

    void SpawnEnemy(GameObject enemyPrefab)
    {
        Transform spawnPoint = enemySpawnPoints[Random.Range(0, enemySpawnPoints.Length)];
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
