using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class diplayWaveIngame : MonoBehaviour
{
    public EnemyWaves enemyWave;
    public TextMeshProUGUI displayWave;

    private void Start()
    {
        enemyWave = GetComponent<EnemyWaves>();
    }

    private void Update()
    {
        displayWave.text = "Wave: " + enemyWave.WaveNum ;
    }
}
