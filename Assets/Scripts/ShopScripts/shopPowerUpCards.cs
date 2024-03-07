using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerUpType
{
    shield,
    damageBuff,
    spiritClone,
    addMaxHealth,
    currencyMultiplier,
    scatterBullet
}

[CreateAssetMenu(fileName = "New Power UP", menuName = "Power Up")]
public class shopPowerUpCards : ScriptableObject
{
    public string powerUPName;
    public string description;
    public Sprite artWork;
    public int cost;
    public PowerUpType powerUpType;
    [HideInInspector] public int powerUpLVL;

    //clone sprite
    [HideInInspector] public Sprite spiritClone_1;
    [HideInInspector] public Sprite spiritClone_2;

    [HideInInspector] public int healthToAdd; //add sa max health
    [HideInInspector] public int damageBuff; //damage buff
    [HideInInspector] public int addShield; //shield buff
    [HideInInspector] public int currencyMultiplierNumber; //currency multiplier
   

    [HideInInspector] public playerPowerUpManager playerPowerUPManager;

    public void ActivatePowerUp()
    { 
        //test lng ung mga name na to xD
        switch (powerUpType)
        {
            case PowerUpType.spiritClone:
                spiritClone();
                break;
            case PowerUpType.damageBuff:
                DamageBuff();           
                break;
            case PowerUpType.shield:
                Speed();
                break;
            case PowerUpType.addMaxHealth:
                addMaxHealth();
                break;
            case PowerUpType.currencyMultiplier:
                currencyMultiplier();
                break;
            case PowerUpType.scatterBullet:
                scatterBullet();
                break;
        }
    }

    #region spirit clone
    void spiritClone()
    {
        playerPowerUPManager.ActivateClonePowerUp(spiritClone_1, spiritClone_2);
    }
    #endregion

    #region shield
    void Speed()
    {
        Debug.Log("using shield!");
    }
    #endregion

    #region Damage buff
    void DamageBuff()
    {
        playerPowerUPManager.activateDamageBuff(damageBuff);
       // Debug.Log("using Damage!");
    }
    #endregion

    #region addMaxHealth
    void addMaxHealth()
    {
        playerPowerUPManager.activateAddMaxHealtBuff(healthToAdd);
        //Debug.Log("using addMaxHealth!");
    }
    #endregion

    #region currencyMultiplier
    void currencyMultiplier()
    {
        Debug.Log("using currencyMultiplier!");
    }
    #endregion

    #region scatterBullet
    void scatterBullet()
    {
        playerPowerUPManager.activateScatterBulletBuff();
        Debug.Log("using scatterBullet!");
    }
#endregion
}


