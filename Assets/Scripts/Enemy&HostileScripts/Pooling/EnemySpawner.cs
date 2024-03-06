using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private EnemyWaves EnemyWaves;

    [SerializeField]
    private Transform InstantiateTransform;

    [SerializeField]
    private int WaveNumber { get; set; }=1;

    [SerializeField]
    private float SpawnRate;

    private float spawnTime;

    private void Start()
    {
        SpawnRate = 10f;
        spawnTime = 0;
        Debug.Log(SpawnRate + " " + spawnTime);
    }

    public void FixedUpdate()
    {
        spawnTime += Time.deltaTime;
        if (spawnTime >= SpawnRate && WaveNumber <= 3 && WaveNumber > 0)
        {
            SpawnRate = 1f /WaveNumber;
            spawnTime = 0f;
            Spawn();
        }
        else if (WaveNumber == 4)
        {
            SpawnRate = 7f;
            StartCoroutine(NextWave());
        }
        else if (EnemyWaves.canSpawn==false)
        {
            SpawnRate = 3f / WaveNumber;
            StartCoroutine(NextWave());
        }
    }

    public void Spawn()
    {
        var enemy = EnemyWaves.Get(WaveNumber, InstantiateTransform.position, InstantiateTransform.rotation);
    }

    IEnumerator NextWave()
    {
        yield return new WaitForSeconds(SpawnRate);

        if (WaveNumber <= 3)
        {
            WaveNumber = EnemyWaves.ResetEnemyCount();
        }
        else
        {
            WaveNumber = 0;
            GameObject Boss = GetComponentInChildren<BossSpawner>().SpawnRandomBoss();
            yield return new WaitWhile(()=>(Boss.activeSelf));
            WaveNumber = 1;
        }
    }
}