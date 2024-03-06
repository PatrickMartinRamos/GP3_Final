using UnityEngine;
using UnityEngine.Pool;

public class EnemyWaves : MonoBehaviour
{
    [SerializeField]
    private Enemy EnemyPrefab;
    private ObjectPool<Enemy>enemies;
    [SerializeField]
    private int enemiesPerWave, enemiesSpawned, WaveNum, enemiesCreated = 0;
    public bool canSpawn;

    private void Awake()
    {
       enemies = new ObjectPool<Enemy>(CreateEnemy, OnEnemyGet, OnEnemyRelease, OnEnemyDestroy, true, 20, 20);

    }

    private void OnDestroy()
    {
       enemies?.Clear();
       enemies?.Dispose();
    }

    private void Update()
    {
        canSpawn = enemiesSpawned < enemiesPerWave ? true:false;
    }
    public Enemy Get(int WaveNumber, Vector3 position, Quaternion rotation)
    {
        WaveNum = WaveNumber;
        enemiesPerWave = WaveNumber * 5;
        while (canSpawn)
        {
            var enemy = enemies.Get();
            if (enemy != null)
            {
                enemy.transform.SetPositionAndRotation(position, rotation);
            }
            return enemy;
        }
 
        WaveNum++;
        Debug.Log("WAVE NUMBER " + WaveNum);
        return null;
    }
    public Enemy Summon(int Number, Vector3 position, Quaternion rotation)
    {
        enemiesPerWave = Number;
        while (canSpawn)
        {
            var enemy = enemies.Get();
            if (enemy != null)
            {
                enemy.transform.SetPositionAndRotation(position, rotation);
            }
            return enemy;
        }
        return null;
    }
    public int ResetEnemyCount()
    {
        enemiesSpawned = 1;
        return WaveNum;
    }

    private Enemy CreateEnemy()
    {
        var instance = Instantiate(EnemyPrefab);
        instance.EnemyID = enemiesCreated++;
        instance.ObjectPool = enemies;
        return instance;  
    }

    private void OnEnemyGet(Enemy enemy)
    {
        enemy.WaveNum = WaveNum;
        enemy.rb.velocity = Vector3.zero;
        enemiesSpawned++;
        Debug.Log($"Total Number Spawned = {enemiesSpawned}");
        enemy.gameObject.SetActive(true);
    }

    private void OnEnemyRelease(Enemy enemy) => enemy.gameObject.SetActive(false);

    private void OnEnemyDestroy(Enemy enemy) => Destroy(enemy.gameObject);
}