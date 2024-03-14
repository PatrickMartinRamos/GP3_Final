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

    #region start/update
    private void Start()
    {
        _playerManager = playerManagerScript._playerManagerInstance;

        // Populate the healthObjects array with all the health objects in the scene
        healthObjects = GameObject.FindGameObjectsWithTag("Health");
    }

    private void Update()
    {
        uiDisplay();
    }
    #endregion

    #region UI Display
    void uiDisplay()
    {
        _displayHealth.text = "Health: " + _playerManager._playerCurrentHealth.ToString() + "/" + _playerManager._maxHealth.ToString();
        _displayShield.text = "Shield: " + _playerManager._playerCurrentShield.ToString() + "/" + _playerManager._playerMaxShield.ToString();

        if (_playerManager.isShieldCooldown)
        {
            float remainingCooldown = Mathf.Max(0, _playerManager._shieldCooldown - _playerManager.timeSinceShieldDamage);
            _displayCooldown.text = "Shield Cooldown: " + remainingCooldown.ToString("F1") + "s";
        }
        else
        {
            _displayCooldown.text = "Shield Cooldown: Ready";
        }

        // Activate or deactivate health objects based on player's current health
        for (int i = 0; i < healthObjects.Length; i++)
        {
            healthObjects[i].SetActive(i < _playerManager._playerCurrentHealth);
        }
    }
    #endregion
}
