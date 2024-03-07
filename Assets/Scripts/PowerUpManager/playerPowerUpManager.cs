using UnityEngine;

public class playerPowerUpManager : MonoBehaviour
{
    playerManagerScript _playerManager;
    public bulletManager _bulletManager;

    [Header("Clone Wisp")]
    //clone(wisp) Var
    public GameObject spiritClone_1;
    public GameObject spiritClone_2;
    public int _cloneLevel;

    //addMaxHealth
    public int _addMaxHealthLevel;

    //Shield Var

    [Header("Scatter Bullet")]
    //Scatter Bullet Var
    public Transform _scatterBulletPOS_1;
    public Transform _scatterBulletPOS_2;
    [HideInInspector] public bool _scatterBullet_1 = false;
    [HideInInspector]  public bool _scatterBullet_2 = false;
    public int _scatterBulletLevel;

    //Bullet Buff Var
    public int _damageBuffLevel;


    private void Start()
    {
        _playerManager = playerManagerScript._playerManagerInstance;
        _bulletManager = FindObjectOfType<bulletManager>();
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
    public void activateScatterBulletBuff()
    {
        IncreaseScatterBulletLevel();

        switch(_scatterBulletLevel)
        {
            case 1:
                _scatterBullet_1 = true;
                break;
            case 2:
                _scatterBullet_2 = true;
                break;
            case 3:
                Debug.Log("power up 3");
                break;
        }
    }

    public void IncreaseScatterBulletLevel()
    {
        _scatterBulletLevel++;
    }

    #endregion

    #region addMaxHealtBuff
    public void activateAddMaxHealtBuff(int healthToAdd)
    {
        IncreaseAddMaxHealthLevel();

        _playerManager.IncreaseMaxHealth(healthToAdd);
    }

    public void IncreaseAddMaxHealthLevel()
    {
        _addMaxHealthLevel++;
    }
    #endregion

    #region activateDamageBuff
    public void activateDamageBuff(int damageBuff)
    {
        _bulletManager.increasedBulletDamage(damageBuff);
        IncreaseDamageBuffLevel();
    }
    public void IncreaseDamageBuffLevel()
    {
        _damageBuffLevel++;
    }
    #endregion
}
