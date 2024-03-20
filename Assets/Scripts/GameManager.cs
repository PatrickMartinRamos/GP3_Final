using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public shopPowerUpManager powerUpManager;

    public static GameManager instance { get; set; }

    [Header("GameObjects")]
    public GameObject Player;
    public GameObject UpcomingBoss { get; set; }

    [Header("Scripts")]
    public EnemyWaves eWaves;
    public EnemySpawner eSpawner;
    public BossSpawner bSpawner;

    [Header("Text Fields")]
    public GameObject waveNotif;

    public void Awake()
    {
        if (instance != null && instance != this) { Destroy(this); }
        else { instance = this; }

        eWaves = GetComponentInChildren<EnemyWaves>();
        eSpawner = GetComponentInChildren<EnemySpawner>();
        bSpawner = GetComponentInChildren<BossSpawner>();
    }
}