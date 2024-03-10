using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class powerCardDisplay : MonoBehaviour
{
    public shopPowerUpCards _powerUpCard;

    public TextMeshProUGUI description;
    public TextMeshProUGUI namePowerUP;

    public Image artWork;

    // Start is called before the first frame update
    public void Start()
    {
        if (_powerUpCard != null)
        {
            namePowerUP.text = _powerUpCard.name;
            description.text = _powerUpCard.description;
            artWork.sprite = _powerUpCard.artWork;

        }
        else
        {
            Debug.LogError("No shopPowerUpCards assigned to powerCardDisplay.");
        }
    }
}
