using TMPro;
using UnityEngine;

public class onBuyScript : MonoBehaviour
{
    public shopPowerUpManager shopPowerUpManager;
    public playerPowerUpManager playerPowerUpManager;

    public GameObject[] particleEffect;
    public GameObject _powerUpShop;
    

    public void OnBuyButtonClick(int cardIndex)
    {
        if (cardIndex >= 0 && cardIndex < shopPowerUpManager.powerUpCardDisplays.Count)
        {
            powerCardDisplay powerCardDisplayComponent = shopPowerUpManager.powerUpCardDisplays[cardIndex];

            // Access the powerUpCard from the powerCardDisplay component
            shopPowerUpCards powerUpCard = powerCardDisplayComponent._powerUpCard;

            // Check if the player has already purchased this card three times
            if (powerUpCard.powerUpLVL < 3)
            {
                // Assign the playerPowerUpManager reference
                powerUpCard.playerPowerUPManager = playerPowerUpManager;

                // Increment the level count
                powerUpCard.powerUpLVL++;

                Debug.Log("Power-Up Name: " + powerUpCard.powerUPName + "\n level " + powerUpCard.powerUpLVL);

                // Activate the power-up
                powerUpCard.ActivatePowerUp();
                _powerUpShop.SetActive(false);

                // Update the card display level using the powerCardDisplay component
                powerCardDisplayComponent.UpdateCardLevel();
            }
            else
            {
                Debug.Log("You have already purchased this power-up three times.");
            }
        }
    }
}
