using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class powerCardDisplay : MonoBehaviour
{
    public shopPowerUpCards _powerUpCard;

    public TextMeshProUGUI costTxt;
    public TextMeshProUGUI description;
    public TextMeshProUGUI namePowerUP;

    public Image artWork;

    // Start is called before the first frame update
    public void Start()
    {
        namePowerUP.text = _powerUpCard.name;
        description.text = _powerUpCard.description;

        artWork.sprite = _powerUpCard.artWork;

        costTxt.text = _powerUpCard.cost.ToString();
    }

}
