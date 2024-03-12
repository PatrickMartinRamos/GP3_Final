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
    }
    #endregion
}
