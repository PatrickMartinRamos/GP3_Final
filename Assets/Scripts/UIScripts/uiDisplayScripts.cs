using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class uiDisplayScripts : MonoBehaviour
{
    //public var
    public TextMeshProUGUI _displayHealth;
    public TextMeshProUGUI _displayCurrency;

    public playerManagerScript _playerManager;

    private void Start()
    {
        _playerManager = playerManagerScript._playerManagerInstance;
    }
    private void Update()
    {
        uiDisplayHealth();
        uiDisplayCurrency();
    }

    void uiDisplayHealth()
    {
        _displayHealth.text = "Health: "+ _playerManager._playerCurrentHealth.ToString() + "/"  + _playerManager._maxHealth.ToString();
    }

    void uiDisplayCurrency()
    {
        _displayCurrency.text = "Currency: " + _playerManager.currencyEarned.ToString();
    }
}
