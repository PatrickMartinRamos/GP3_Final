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
            SpawnRate = 2f / WaveNumber;
            spawnTime = 0f;
            Spawn();
        }
        else if (spawnTime >= SpawnRate && WaveNumber == 4 && EnemyWaves.ActiveEnemies == 0)
        {
            SpawnRate = 10f;
            StartCoroutine(NextWave());
        }
        else if (EnemyWaves.canSpawn == false && EnemyWaves.ActiveEnemies == 0)
        {
            SpawnRate = 3f / WaveNumber;
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

        if (WaveNumber <= 3)
        {
            WaveNumber = EnemyWaves.ResetEnemyCount();
        }
        else
        {
            WaveNumber = 0;
            Boss = GameManager.instance.UpcomingBoss;
            GameManager.instance.UpcomingBoss = GameManager.instance.bSpawner.SpawnRandomBoss();

        yield return new WaitWhile(() => (Boss.activeSelf));
            GameManager.instance.powerUpManager.gameObject.SetActive(true);

        yield return new WaitWhile(() => (GameManager.instance.powerUpManager.gameObject.activeSelf));
            WaveNumber = 1;
            GameObject temp = GameManager.instance.UpcomingBoss;
            while (temp.gameObject.name == GameManager.instance.UpcomingBoss.name)
            {
                temp = GameManager.instance.bSpawner.GetBossToSpawn();
                if (temp != null)
                { 
                    GameManager.instance.UpcomingBoss = temp;
                }
                else
                    temp = GameManager.instance.UpcomingBoss;
            }

        }
    }


}