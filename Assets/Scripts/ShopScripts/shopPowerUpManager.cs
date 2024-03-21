using System.Collections.Generic;
using UnityEngine;

public class shopPowerUpManager : MonoBehaviour
{
    public List<shopPowerUpCards> allPowerUps;
    public List<powerCardDisplay> powerUpCardDisplays;
    public List<powerCardDisplay> unlimitedPowerUpCardDisplays; // List for unlimited power-up card displays
    public List<shopPowerUpCards> unlimitedPowerUps; // List for unlimited power-up cards

    private const int requiredCardCount = 2;

    void Start()
    {
        if (!ValidatePowerUpCardDisplays())
            return;

        if (!ValidatePowerUps())
            return;

        Shuffle(allPowerUps);
        ResetPowerUpLevels();
        AssignRandomPowerUpsToCards();
    }

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

    void AssignRandomPowerUpsToCards()
    {
        if (AllNormalCardsAtLevelThree())
        {
            HideNormalPowerUpCards();
            ShowUnlimitedPowerUpCards();
            AssignUnlimitedPowerUpsToCards();
            return;
        }

        HideUnlimitedPowerUpCards();

        for (int i = 0; i < requiredCardCount; i++)
        {
            shopPowerUpCards randomPowerUp = GetRandomPowerUpWithLevelLessThanThree();
            if (randomPowerUp != null)
            {
                powerUpCardDisplays[i]._powerUpCard = randomPowerUp;
                powerUpCardDisplays[i].Start(); // Refresh UI with new power up
            }
        }
    }

    bool AllNormalCardsAtLevelThree()
    {
        foreach (var powerUp in allPowerUps)
        {
            if (powerUp.powerUpLVL < 3)
            {
                return false;
            }
        }
        return true;
    }

    void ShowUnlimitedPowerUpCards()
    {
        foreach (var display in unlimitedPowerUpCardDisplays)
        {
            display.gameObject.SetActive(true);
        }
    }

    void HideUnlimitedPowerUpCards()
    {
        foreach (var display in unlimitedPowerUpCardDisplays)
        {
            display.gameObject.SetActive(false);
        }
    }

    void HideNormalPowerUpCards()
    {
        foreach (var display in powerUpCardDisplays)
        {
            display.gameObject.SetActive(false);
        }
    }

    void AssignUnlimitedPowerUpsToCards()
    {
        for (int i = 0; i < requiredCardCount; i++)
        {
            if (i < unlimitedPowerUps.Count)
            {
                unlimitedPowerUpCardDisplays[i]._powerUpCard = unlimitedPowerUps[i];
                unlimitedPowerUpCardDisplays[i].Start(); // Refresh UI with new unlimited power up
            }
        }
    }

    shopPowerUpCards GetRandomPowerUpWithLevelLessThanThree()
    {
        List<shopPowerUpCards> availablePowerUps = new List<shopPowerUpCards>();
        foreach (var powerUp in allPowerUps)
        {
            if (powerUp.powerUpLVL < 3)
            {
                availablePowerUps.Add(powerUp);
            }
        }

        if (availablePowerUps.Count > 0)
        {
            int randomIndex = Random.Range(0, availablePowerUps.Count);
            return availablePowerUps[randomIndex];
        }

        return null; // Return null if all power-ups are at level 3
    }

    public void Shuffle<T>(List<T> list)
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

    public void ResetPowerUpLevels()
    {
        Debug.Log("reset");
        foreach (var powerUp in allPowerUps)
        {
            powerUp.powerUpLVL = 0; // Reset power-up level to 0 for each power-up card
        }
    }
}
