using UnityEngine;
using UnityEngine.Pool;

public class EnemyWaves : MonoBehaviour
{
    [SerializeField]
    private Enemy EnemyPrefab;
    private ObjectPool<Enemy>enemies;
    [SerializeField]
    private int enemiesPerWave, enemiesSpawned, WaveNum;

    private void Awake()
    {
       enemies = new ObjectPool<Enemy>(CreateEnemy, OnEnemyGet, OnEnemyRelease, OnEnemyDestroy, true, 5, 10);
    }

    private void OnDestroy()
    {
       enemies?.Clear();
       enemies?.Dispose();
    }

    public Enemy Get(int WaveNumber, Vector3 position, Quaternion rotation)
    {
        WaveNum = WaveNumber;
        enemiesPerWave = WaveNumber * 5;
        if (canSpawn())
        {
            var enemy = enemies.Get();
            if (enemy != null)
            {
                enemiesSpawned++;
                Debug.Log($"Total Number Spawned = {enemiesSpawned}");
                enemy.transform.SetPositionAndRotation(position, rotation);
            }
            return enemy;
        }
        else
        {
            WaveNum++;
            Debug.Log("WAVE NUMBER " + WaveNum);
            return null;
        }

    }
    public bool canSpawn()
    {
        if (enemiesSpawned < enemiesPerWave)
        {
            return true;
        }
        else
            return false;
    }
    public int ResetEnemyCount()
    {
        enemiesSpawned = 0;
        return WaveNum;
    }

    private Enemy CreateEnemy()
    {
        var instance = Instantiate(EnemyPrefab);
        instance.ObjectPool = enemies;
        return instance;  
    }

    private void OnEnemyGet(Enemy enemy)
    {
        enemy.rb.velocity = Vector3.zero;
        enemy.gameObject.SetActive(true);
    }

    private void OnEnemyRelease(Enemy enemy) => enemy.gameObject.SetActive(false);

    private void OnEnemyDestroy(Enemy enemy) => Destroy(enemy.gameObject);
}