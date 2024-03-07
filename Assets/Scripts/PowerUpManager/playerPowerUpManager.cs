using UnityEngine;

public class playerPowerUpManager : MonoBehaviour
{
    playerManagerScript _playerManager;

    [Header("Clone Wisp")]
    //clone(wisp) Var
    public GameObject spiritClone_1;
    public GameObject spiritClone_2;
    public int _cloneLevel;

    //addMaxHealth

    //Shield Var

    [Header("Scatter Bullet")]
    //Scatter Bullet Var
    public GameObject _scatterBulletPOS_1;
    public GameObject _scatterBulletPOS_2;
    [HideInInspector] public bool _scatterBullet_1;
    [HideInInspector]  public bool _scatterBullet_2;
    public int _scatterBulletLevel;

    //Bullet Buff Var


    private void Start()
    {
        _playerManager = playerManagerScript._playerManagerInstance;
    }

    #region activate clone(wisp)
    public void ActivateClonePowerUp(Sprite sprite1, Sprite sprite2)
    {
        IncreaseCloneLevel();
        // Activate the appropriate number of clones based on the level
        switch (_cloneLevel)
        {
            case 1:
                spiritClone_1.SetActive(true); 
                spiritClone_2.SetActive(false);
                break;
            case 2:
                spiritClone_1.SetActive(true);
                spiritClone_2.SetActive(true);
                break;
            case 3:
                //add damaage to the spriti clone
                break;
        }

        // Assign sprites
        SpriteRenderer spriteRenderer1 = spiritClone_1.GetComponent<SpriteRenderer>();
        SpriteRenderer spriteRenderer2 = spiritClone_2.GetComponent<SpriteRenderer>();

        if (spriteRenderer1 != null && spriteRenderer2 != null)
        {
            spriteRenderer1.sprite = sprite1;
            spriteRenderer2.sprite = sprite2;
        }
    }

    // Method to increase the clone level
    public void IncreaseCloneLevel()
    {
        _cloneLevel++;
    }
    #endregion

    #region scatterBulletBuff
    public void scatterBulletBuff()
    {

    }
    #endregion

    #region addMaxHealtBuff
    public void addMaxHealtBuff(int healthToAdd)
    {
        IncreaseAddMaxHealthLevel();

        _playerManager.IncreaseMaxHealth(healthToAdd);
    }
    // Method to increase the clone level
    public void IncreaseAddMaxHealthLevel()
    {
        _scatterBulletLevel++;
    }
    #endregion
}
