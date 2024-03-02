using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public shopPowerUpManager powerUpManager;

    public void resetPowerUPLVL()
    {
        if (powerUpManager != null)
        {
            powerUpManager.ResetPowerUpLevels();
            Debug.Log("PowerLVL reset");
        }
        else
        {
            Debug.LogError("PowerUpManager reference is not set in the GameManager.");
        }
    }
}
