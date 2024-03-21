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
        enemyWave = GameManager.instance.eWaves;
    }

    private void Update()
    {
        if (enemyWave.WaveNum > 1 && enemyWave.WaveNum < 4)
        {
            displayWave.text = "Round: " + enemyWave.roundNumber + "\nWave: " + enemyWave.WaveNum;
        }
        else if (enemyWave.WaveNum == 4)
        {
            displayWave.text = "Incoming Boss!!!";
        }
        else if (enemyWave.WaveNum == 1)
        {
            displayWave.text = "Round: " + enemyWave.roundNumber + "\nWave: " + enemyWave.WaveNum;
        }
    }
}
