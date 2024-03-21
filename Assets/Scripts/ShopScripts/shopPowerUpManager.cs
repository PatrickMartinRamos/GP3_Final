using System.Collections.Generic;
using UnityEngine;

public class shopPowerUpManager : MonoBehaviour
{
    // Lists to store all power-ups, power-up card displays, unlimited power-up card displays, and unlimited power-ups
    public List<shopPowerUpCards> allPowerUps;
    public List<powerCardDisplay> powerUpCardDisplays;
    public List<powerCardDisplay> unlimitedPowerUpCardDisplays; // List for unlimited power-up card displays
    public List<shopPowerUpCards> unlimitedPowerUps; // List for unlimited power-up cards
    public GameObject shuffleButton; // Button to shuffle power-ups

    // Constants for validation and reshuffling
    private const int requiredCardCount = 2;
    private int reshuffleCount = 0;
    private const int maxReshuffleCount = 2; // Maximum allowed reshuffle count

    void Start()
    {
        // Validate and initialize power-up cards and power-ups
        if (!ValidatePowerUpCardDisplays())
            return;

        if (!ValidatePowerUps())
            return;

        // Shuffle power-ups and assign them to cards
        Shuffle(allPowerUps);
        ResetPowerUpLevels();
        AssignRandomPowerUpsToCards();
    }

    // Method to validate power-up card displays
    bool ValidatePowerUpCardDisplays()
    {
        if (powerUpCardDisplays.Count < requiredCardCount)
        {
            Debug.LogError("Not enough power-up card displays assigned!");
            return false;
        }
        return true;
    }

    // Method to validate power-ups
    bool ValidatePowerUps()
    {
        if (allPowerUps.Count < requiredCardCount)
        {
            Debug.LogError("Not enough power-ups to choose from!");
            return false;
        }
        return true;
    }

    // Method to assign random power-ups to cards
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

    // Check if all normal cards are at level 3
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

    // Show unlimited power-up cards
    void ShowUnlimitedPowerUpCards()
    {
        foreach (var display in unlimitedPowerUpCardDisplays)
        {
            display.gameObject.SetActive(true);
        }
    }

    // Hide unlimited power-up cards
    void HideUnlimitedPowerUpCards()
    {
        foreach (var display in unlimitedPowerUpCardDisplays)
        {
            display.gameObject.SetActive(false);
        }
    }

    // Hide normal power-up cards
    void HideNormalPowerUpCards()
    {
        foreach (var display in powerUpCardDisplays)
        {
            display.gameObject.SetActive(false);
        }
    }

    // Assign unlimited power-ups to cards
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

    // Get a random power-up with level less than three
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

    // Shuffle a list
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

    // Reshuffle power-ups
    public void ReshufflePowerUps()
    {
        if (reshuffleCount < maxReshuffleCount)
        {
            Shuffle(allPowerUps);
            AssignRandomPowerUpsToCards();
            reshuffleCount++;
        }
        else
        {
            shuffleButton.SetActive(false);
            Debug.Log("Maximum reshuffle limit reached.");
        }
    }

    // Reset shuffle count
    public void resetShuffleCount()
    {
        Debug.Log("Reset shuffle count.");
        reshuffleCount = 0;
    }

    // Reset power-up levels
    public void ResetPowerUpLevels()
    {
        Debug.Log("Reset power-up levels.");
        foreach (var powerUp in allPowerUps)
        {
            powerUp.powerUpLVL = 0; // Reset power-up level to 0 for each power-up card
        }
    }

}
