using TMPro;
using UnityEngine;

public class onBuyScript : MonoBehaviour
{
    public shopPowerUpManager shopPowerUpManager;
    public playerPowerUpManager playerPowerUpManager;

    public GameObject[] particleEffect;
    public GameObject _powerUpShop;

    // Reference to the musicManager
    public musicManager musicManager;

    void Start()
    {
        // Get the musicManager component
        musicManager = FindObjectOfType<musicManager>();
    }


    public void OnBuyButtonClick(int cardIndex)
    {
        if (cardIndex >= 0 && cardIndex < shopPowerUpManager.powerUpCardDisplays.Count)
        {
            powerCardDisplay powerCardDisplayComponent = shopPowerUpManager.powerUpCardDisplays[cardIndex];
            shopPowerUpCards powerUpCard = powerCardDisplayComponent._powerUpCard;

            if (powerUpCard.powerUpLVL < 3)
            {
                powerUpCard.playerPowerUPManager = playerPowerUpManager;
                powerUpCard.powerUpLVL++;
                Debug.Log("Power-Up Name: " + powerUpCard.powerUPName + "\n level " + powerUpCard.powerUpLVL);
                powerUpCard.ActivatePowerUp();
                _powerUpShop.SetActive(false);
                powerCardDisplayComponent.UpdateCardLevel();

                // Call the method in musicManager to play the button SFX
                musicManager.PlayButtonSFX();
                shopPowerUpManager.ReshufflePowerUps();
                shopPowerUpManager.resetShuffleCount();
                shopPowerUpManager.shuffleButton.SetActive(true);
            }
            else
            {            
                Debug.Log("You have already purchased this power-up three times.");
            }
        }
    }

    public void PurchaseUnlimitedPowerUp(int cardIndex)
    {
        if (cardIndex >= 0 && cardIndex < shopPowerUpManager.unlimitedPowerUpCardDisplays.Count)
        {

            powerCardDisplay powerCardDisplayComponent = shopPowerUpManager.unlimitedPowerUpCardDisplays[cardIndex];
            shopPowerUpCards powerUpCard = powerCardDisplayComponent._powerUpCard;
            powerUpCard.playerPowerUPManager = playerPowerUpManager;

            // Handle assignment of unlimited power-up here
            Debug.Log("Unlimited Power-Up Purchased: " + powerUpCard.powerUPName);
            powerUpCard.ActivatePowerUp();
            musicManager.PlayButtonSFX();
            shopPowerUpManager.resetShuffleCount();
            shopPowerUpManager.shuffleButton.SetActive(true);
            _powerUpShop.SetActive(false);

        }
    }



}
