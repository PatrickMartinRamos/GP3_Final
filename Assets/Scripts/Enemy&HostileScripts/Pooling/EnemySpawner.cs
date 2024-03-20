using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private EnemyWaves EnemyWaves;

    public Transform InstantiateTransform;

    [SerializeField]
    private int WaveNumber { get; set; }=1;

    [SerializeField]
    private float SpawnRate;

    private float spawnTime;
    public GameObject Boss;

    private void Start()
    {
        EnemyWaves = GameManager.instance.eWaves;
        SpawnRate = 5f;
        spawnTime = 0;
        Debug.Log(SpawnRate + " " + spawnTime);
    }

    public void Update()
    {
        spawnTime += Time.deltaTime;
        if (spawnTime >= SpawnRate && WaveNumber <= 3 && WaveNumber > 0 && !GameManager.instance.eWaves.fillingPool)
        {
            GameManager.instance.waveNotif.SetActive(false);
            SpawnRate = 2f / WaveNumber;
            spawnTime = 0f;
            Spawn();
        }
        else if (spawnTime >= SpawnRate && WaveNumber == 4 && EnemyWaves.ActiveEnemies == 0)
        {
            SpawnRate = 5f;
            StartCoroutine(NextWave());
        }
        else if (EnemyWaves.canSpawn == false && EnemyWaves.ActiveEnemies == 0)
        {
            GameManager.instance.waveNotif.SetActive(true);
            SpawnRate = 3f / WaveNumber;
            StartCoroutine(NextWave());
        }
        else if (WaveNumber == 0)
        {
            StartCoroutine(NextWave());
        }
    }

    public void Spawn()
    {
        EnemyWaves.Get(WaveNumber, InstantiateTransform.position, InstantiateTransform.rotation);
    }

    IEnumerator NextWave()
    {
        yield return new WaitForSeconds(SpawnRate);

        if (WaveNumber > 0 && WaveNumber <= 3)
        {
            WaveNumber = EnemyWaves.ResetEnemyCount();
        }
        else if (WaveNumber == 4)
        {
            GameManager.instance.waveNotif.SetActive(false);
            Boss = GameManager.instance.UpcomingBoss;
            GameManager.instance.UpcomingBoss = GameManager.instance.bSpawner.SpawnRandomBoss();

            yield return new WaitWhile(() => (Boss.activeSelf));
            {
                GameManager.instance.powerUpManager.gameObject.SetActive(true);
                WaveNumber = 0;
                EnemyWaves.setWave(0);
            }

        }
        else
        {
            yield return new WaitUntil(() => (!GameManager.instance.powerUpManager.gameObject.activeSelf));
            GameObject temp = GameManager.instance.UpcomingBoss;
            GameManager.instance.UpcomingBoss = GameManager.instance.bSpawner.GetBossToSpawn();
            yield return new WaitForSeconds(3);
            WaveNumber = 1;
            EnemyWaves.setWave(1);
            spawnTime = 0;
            GameManager.instance.waveNotif.SetActive(true);


        }
    }
}