using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UIElements;

public class EnemyWaves : MonoBehaviour
{
    public List<Enemy> Enemylist;
    [SerializeField]
    private Enemy EnemyPrefab;
    private ObjectPool<Enemy>skull;
    private ObjectPool<Enemy> eyeGroup;
    private ObjectPool<Enemy> enemyType3;
    [SerializeField]
    private int enemiesPerWave, enemiesSpawned, WaveNum, enemiesCreated = 0;
    public bool canSpawn;
    public bool fillingPool;
    public int ActiveEnemies=0;

    private void Awake()
    {
        fillingPool = true;
        skull = new ObjectPool<Enemy>(CreateEnemy, OnEnemyGet, OnEnemyRelease, OnEnemyDestroy, true, 0, 20);
        eyeGroup = new ObjectPool<Enemy>(CreateEnemy, OnEnemyGet, OnEnemyRelease, OnEnemyDestroy, true, 0, 20);
        enemyType3 = new ObjectPool<Enemy>(CreateEnemy, OnEnemyGet, OnEnemyRelease, OnEnemyDestroy, true, 0, 20);
    }

    private void OnDestroy()
    {
        skull?.Clear();
        skull?.Dispose();
        eyeGroup?.Clear();
        eyeGroup?.Dispose();
        enemyType3?.Clear();
        enemyType3?.Dispose();

    }

    private void Update()
    {
        canSpawn = enemiesSpawned < enemiesPerWave ? true:false;

        while (fillingPool)
        {
            enemiesPerWave = 20;
            for (int i = 0; i<Enemylist.Count; i++)
            {
                bool fin=false;
                if(i == 0)
                {
                    EnemyPrefab = Enemylist[0];
                    while (fin)
                        fin = FillPool(skull, GameManager.instance.eSpawner.InstantiateTransform.position, GameManager.instance.eSpawner.InstantiateTransform.rotation);
                }
                else if (i == 1)
                {
                    EnemyPrefab = Enemylist[1];
                    while (fin)
                        fin = FillPool(eyeGroup, GameManager.instance.eSpawner.InstantiateTransform.position, GameManager.instance.eSpawner.InstantiateTransform.rotation);
                }
                else if (i == 2)
                {
                    EnemyPrefab = Enemylist[2];
                    while (fin)
                        fin = FillPool(enemyType3, GameManager.instance.eSpawner.InstantiateTransform.position, GameManager.instance.eSpawner.InstantiateTransform.rotation);
                    GameManager.instance.UpcomingBoss = GameManager.instance.bSpawner.GetBossToSpawn();
                    fillingPool = false;
                }
                enemiesSpawned = 0;
            }
        }

    }
    private bool FillPool(ObjectPool<Enemy> pool, Vector3 position, Quaternion rotation)
    {
        while (canSpawn)
        {
            pool.Release(GetEnemy(pool, position, rotation));
            return false;
        }
        Debug.Log(pool.ToString() + pool.CountAll);
        return true;
    }
    public Enemy Get(int WaveNumber, Vector3 position, Quaternion rotation)
    {
        ObjectPool<Enemy> pool = GetPool();
        WaveNum = WaveNumber;
        enemiesPerWave = WaveNumber * 5;
        return GetEnemy(pool, position, rotation);

    }
    public Enemy Summon(int Number, Vector3 position, Quaternion rotation)
    {
        ObjectPool<Enemy> pool = GetPool();
        enemiesPerWave = Number;
        return GetEnemy(pool, position, rotation);
    }
    private Enemy GetEnemy(ObjectPool<Enemy> pool, Vector3 position, Quaternion rotation)
    {
        while (canSpawn)
        {
            var enemy = pool.Get();
            if (enemy != null)
            {
                enemy.transform.SetPositionAndRotation(position, rotation);
            }
            return enemy;
        }
        if (!fillingPool)
        {
            WaveNum++;
            Debug.Log("WAVE NUMBER " + WaveNum);
        }
        return null;
    }
    public int ResetEnemyCount()
    {
        enemiesSpawned = 1;
        return WaveNum;
    }
    ObjectPool<Enemy> GetPool()
    {
        if (GameManager.instance.UpcomingBoss == null)
        {
            EnemyPrefab = Enemylist[0];
            return skull;
        }
        else if (GameManager.instance.UpcomingBoss.name == "Boss 1(Clone)")
        {
            EnemyPrefab = Enemylist[0];
            return skull;
        }
        else if (GameManager.instance.UpcomingBoss.name == "Boss 2(Clone)")
        {
            EnemyPrefab = Enemylist[1];
            return eyeGroup;
        }
        else if (GameManager.instance.UpcomingBoss.name == "Boss3(Clone)")
        {
            EnemyPrefab = Enemylist[2];
            return enemyType3;
        }
        else return null;
    }
    private Enemy CreateEnemy()
    {
        var pool = GetPool();
        var instance = Instantiate(EnemyPrefab);
        instance.EnemyID = enemiesCreated++;
        instance.ObjectPool = pool;
        return instance;  
    }

    private void OnEnemyGet(Enemy enemy)
    {
        enemy.WaveNum = WaveNum;
        enemy.rb.velocity = Vector3.zero;
        enemiesSpawned++;
        ActiveEnemies++;
        Debug.Log($"Total Number Spawned = {enemiesSpawned}");
        enemy.gameObject.SetActive(true);
    }

    private void OnEnemyRelease(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
        ActiveEnemies--;
    }

    private void OnEnemyDestroy(Enemy enemy) => Destroy(enemy.gameObject);
}