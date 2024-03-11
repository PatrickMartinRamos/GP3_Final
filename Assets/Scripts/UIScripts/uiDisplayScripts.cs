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

    private void Start()
    {
        _playerManager = playerManagerScript._playerManagerInstance;
    }
    private void Update()
    {
        uiDisplay();
    }

    void uiDisplay()
    {
        _displayHealth.text = "Health: "+ _playerManager._playerCurrentHealth.ToString() + "/"  + _playerManager._maxHealth.ToString();
        _displayShield.text = "Shield: "+ _playerManager._playerCurrentShield.ToString() + "/"  + _playerManager._playerMaxShield.ToString();

        if (_playerManager.isUsingShield && _playerManager._playerCurrentShield < _playerManager._playerMaxShield && _playerManager.isShieldCooldown)
        {
            // Calculate remaining cooldown time
            float remainingCooldown = Mathf.Max(0, _playerManager._shieldCooldown - Time.time);

            // Display remaining cooldown time
            _displayCooldown.text = "Shield Cooldown: " + remainingCooldown.ToString("F1");
        }

    }
}
