using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class uiDisplayScripts : MonoBehaviour
{
    //public var
    public TextMeshProUGUI _displayHealth;
    public TextMeshProUGUI _displayShield;
    public TextMeshProUGUI _displayCooldown;

    public playerManagerScript _playerManager;

    // Array to hold all health objects
    public GameObject[] healthObjects;
    public GameObject[] shieldSprite;

    #region start/update
    private void Start()
    {
        _playerManager = playerManagerScript._playerManagerInstance;
    }

    private void Update()
    {
        uiDisplay();

    }
    #endregion

    #region UI Display
    void uiDisplay()
    {
        _displayHealth.text = "Health: ";

        if (_playerManager.isUsingShield)
        {
            _displayShield.text = "Shield: ";

            if (_playerManager.isShieldCooldown)
            {
                float remainingCooldown = Mathf.Max(0, _playerManager._shieldCooldown - _playerManager.timeSinceShieldDamage);
                _displayCooldown.text = remainingCooldown.ToString("F1") + "s";

                // Calculate the alpha based on the shield cooldown
                float alpha = Mathf.Clamp01(1.0f - (remainingCooldown / _playerManager._shieldCooldown));

                // Set alpha for each shield sprite
                for (int i = 0; i < shieldSprite.Length; i++)
                {
                    if (i < _playerManager._playerCurrentShield)
                    {
                        Color color = shieldSprite[i].GetComponent<SpriteRenderer>().color;
                        color.a = (i == _playerManager._playerCurrentShield - 1) ? alpha : 1.0f;
                        shieldSprite[i].GetComponent<SpriteRenderer>().color = color;
                    }
                }
            }
            else
            {
                for (int i = 0; i < shieldSprite.Length; i++)
                {
                    if (i < _playerManager._playerCurrentShield)
                    {
                        Color color = shieldSprite[i].GetComponent<SpriteRenderer>().color;
                        color.a = 1.0f;
                        shieldSprite[i].GetComponent<SpriteRenderer>().color = color;
                    }
                }
            }
        }
        else
        {
            _displayShield.text = "";
            _displayCooldown.text = "";
        }

        for (int i = 0; i < healthObjects.Length; i++)
        {
            healthObjects[i].SetActive(i < _playerManager._playerCurrentHealth);
        }

        for (int i = 0; i < shieldSprite.Length; i++)
        {
            shieldSprite[i].SetActive(i < _playerManager._playerCurrentShield);
        }
    }


    #endregion
}
