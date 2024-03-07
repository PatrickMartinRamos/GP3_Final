using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopPowerUpManager : MonoBehaviour
{
    public List<shopPowerUpCards> allPowerUps;

    public List<powerCardDisplay> powerUpCardDisplays;

    private const int requiredCardCount = 3;

    void Start()
    {
        if (!ValidatePowerUpCardDisplays())
            return;

        if (!ValidatePowerUps())
            return;

        Shuffle(allPowerUps);

        AssignRandomPowerUpsToCards();
    }
    #region validation check
    bool ValidatePowerUpCardDisplays()
    {
        if (powerUpCardDisplays.Count < requiredCardCount)
        {
            Debug.LogError("Not enough power-up card displays assigned!");
            return false;
        }
        return true;
    }

    bool ValidatePowerUps()
    {
        if (allPowerUps.Count < requiredCardCount)
        {
            Debug.LogError("Not enough power-ups to choose from!");
            return false;
        }
        return true;
    }
    #endregion

    #region assign random power up to shop cards
    void AssignRandomPowerUpsToCards()
    {
        for (int i = 0; i < requiredCardCount; i++)
        {
            powerUpCardDisplays[i]._powerUpCard = allPowerUps[i];
            powerUpCardDisplays[i].Start(); // Refresh UI with new power up
        }
    }
    #endregion

    #region shuffle shop cards function
    void Shuffle<T>(List<T> list)
    {
        int remainingCount = list.Count;
        while (remainingCount > 1)
        {
            remainingCount--;
            int randomIndex = Random.Range(0, remainingCount + 1);
            T temporaryValue = list[randomIndex];
            list[randomIndex] = list[remainingCount];
            list[remainingCount] = temporaryValue;
        }
    }

    public void ReshufflePowerUps()
    {
        Shuffle(allPowerUps);
        AssignRandomPowerUpsToCards();
    }
    #endregion

    #region reset power-up levels
    public void ResetPowerUpLevels()
    {
        Debug.Log("reset");
        foreach (var powerUp in allPowerUps)
        {
            powerUp.powerUpLVL = 0; // Reset power-up level to 0 for each power-up card
        }
    }
    #endregion
}
