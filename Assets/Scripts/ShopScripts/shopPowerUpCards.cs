using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerUpType
{
    shield,
    damageBuff,
    spiritClone,
    addMaxHealth,
    explodeEnemy,
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
    [HideInInspector] public GameObject _wispBullet;
    //ibahin naten ung image nng wisp bullet wag ung bullet nga gamit ni player
    

    [HideInInspector] public int healthToAdd; //add sa max health
    [HideInInspector] public int damageBuff; //damage buff
    [HideInInspector] public int addShield; //shield buff
    [HideInInspector] public float chanceOfExplostion; //explosion buff

   

    [HideInInspector] public playerPowerUpManager playerPowerUPManager;

    public void ActivatePowerUp()
    { 
        switch (powerUpType)
        {
            case PowerUpType.spiritClone:
                spiritClone();
                break;
            case PowerUpType.damageBuff://done
                DamageBuff();           
                break;
            case PowerUpType.shield:
                Speed();
                break;
            case PowerUpType.addMaxHealth://done
                addMaxHealth();
                break;
            case PowerUpType.explodeEnemy://done
                explodeEnemy();
                break;
            case PowerUpType.scatterBullet://done
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

    #region explodeEnemy
    void explodeEnemy()
    {
        playerPowerUPManager.activateExplosionBuff();
        Debug.Log("explosion chance is " +playerPowerUPManager._explosionChance);
       // Debug.Log("using currencyMultiplier!");
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


