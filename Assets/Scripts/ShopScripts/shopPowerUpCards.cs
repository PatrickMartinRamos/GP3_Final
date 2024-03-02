using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerUpType
{
    Speed,
    Damage,
    Clone,
    Naruto,
    Elden,
    x2
}

[CreateAssetMenu(fileName = "New Power UP", menuName = "Power Up")]
public class shopPowerUpCards : ScriptableObject
{
    public string powerUPName;
    public string description;
    public Sprite artWork;
    public int cost;
    public PowerUpType powerUpType;
    public int powerUpLVL;

    //clone sprite
    [HideInInspector] public Sprite spiritClone_1;
    [HideInInspector] public Sprite spiritClone_2;

    public playerPowerUpManager playerManager;

    public void ActivatePowerUp()
    { 
        //test lng ung mga name na to xD
        switch (powerUpType)
        {
            case PowerUpType.Clone:
                spiritClone();
                break;
            case PowerUpType.Damage:
                Damage();           
                break;
            case PowerUpType.Speed:
                Speed();
                break;
            case PowerUpType.Naruto:
                naruto();
                break;
            case PowerUpType.Elden:
                elden();
                break;
            case PowerUpType.x2:
                x2();
                break;
        }
    }

    #region spirit clone
    void spiritClone()
    {
        playerManager.ActivateClonePowerUp(spiritClone_1, spiritClone_2);
    }
    #endregion

    #region speed
    void Speed()
    {
        Debug.Log("using Speed!");
    }
    #endregion

    #region Damage
    void Damage()
    {
        Debug.Log("using Damage!");
    }
    #endregion

    #region naruto
    void naruto()
    {
        Debug.Log("using naruto!");
    }
    #endregion

    #region elden ring
    void elden()
    {
        Debug.Log("using elden!");
    }
    #endregion

    #region x2
    void x2()
    {
        Debug.Log("using x2!");
    }
#endregion
}


