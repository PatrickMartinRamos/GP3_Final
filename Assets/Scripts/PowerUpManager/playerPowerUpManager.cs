using UnityEngine;

public class playerPowerUpManager : MonoBehaviour
{
    playerManagerScript _playerManager;
    bulletManager _bulletManager;

    #region  book clone
    [Header("Book Clone")]
    //clone(wisp) Var
    public GameObject _bookClone_1;
    public GameObject _booktClone_2;
    public Transform _bulletBookSpawnPoint_1;
    public Transform _bulletBookSpawnPoint_2;
    [HideInInspector] public bool _bookBullet_1 = false;
    [HideInInspector] public bool _bookBullet_2 = false;
    public int _bookLevel;
    #endregion

    #region max health
    //addMaxHealth
    public int _addMaxHealthLevel;
    #endregion

    #region shield
    [Header("Shield")]
    //Shield Var
    public int _shieldBuffLevel;

    public GameObject _shieldBuffObject;
    #endregion

    #region explosion
    [Header("Explosion")]
    //Explotion var
    public int _explotsionLevel;
    [HideInInspector] public float _explosionChance;
    [HideInInspector] public int _explosionDamage;
    #endregion

    #region Scatter bullet
    [Header("Scatter Bullet")]
    //Scatter Bullet Var
    public Transform _scatterBulletPOS_1;
    public Transform _scatterBulletPOS_2;
    [HideInInspector] public bool _scatterBullet_1 = false;
    [HideInInspector]  public bool _scatterBullet_2 = false;
    public int _scatterBulletLevel;
    #endregion

    //Bullet Buff Var
    public int _damageBuffLevel;

    private void Start()
    {
        _explosionDamage = 10;
        _playerManager = playerManagerScript._playerManagerInstance;
        _bulletManager = FindObjectOfType<bulletManager>();

        _shieldBuffObject.SetActive(false);
    }

    #region activate clone(book)
    public void ActivateClonePowerUp(Sprite sprite1, Sprite sprite2)
    {
        IncreaseCloneLevel();
        // Activate the appropriate number of clones based on the level
        switch (_bookLevel)
        {
            case 1:
                _bookClone_1.SetActive(true); 
                _booktClone_2.SetActive(false);
                _bookBullet_1 = true;
                break;
            case 2:           
                _bookBullet_2 = true;
                _bookClone_1.SetActive(true);
                _booktClone_2.SetActive(true);
                break;
            case 3:
                _bulletManager._bulletInterval = .15f;
                //add damaage to the spriti clone
                break;
        }

        // Assign sprites
        SpriteRenderer spriteRenderer1 = _bookClone_1.GetComponent<SpriteRenderer>();
        SpriteRenderer spriteRenderer2 = _booktClone_2.GetComponent<SpriteRenderer>();

        if (spriteRenderer1 != null && spriteRenderer2 != null)
        {
            spriteRenderer1.sprite = sprite1;
            spriteRenderer2.sprite = sprite2;
        }
    }

    // Method to increase the clone level
    public void IncreaseCloneLevel()
    {
        _bookLevel++;
    }
    #endregion // 

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
                _bulletManager.increasedBulletDamage(5);
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

    #region activate explosion buff
    public void activateExplosionBuff()
    {
        IncreaseExplosionLevel();

        switch(_explotsionLevel)
        {
            case 1:
                _explosionChance = .15f;
                _explosionDamage = 1;
                break;
            case 2:
                _explosionChance = .20f;
                _explosionDamage = 3;
                break;
            case 3:
                _explosionChance = .30f;
                _explosionDamage = 5;
                break;
            default:
                break;
        }

    }

    public void IncreaseExplosionLevel()
    {
        _explotsionLevel++;
    }
    #endregion

    #region shield buff
    public void activateShieldBuff(int[] shieldHealthLevel, int[] shieldCooldownLevel)
    {
        IncreaseShieldBuffLevel();

        switch (_shieldBuffLevel)
        {
            case 1:
                _shieldBuffObject.SetActive(true);
                _playerManager.isUsingShield = true;

                _playerManager.IncreasedMaxShieldandDecreaseCooldown(shieldHealthLevel[0], shieldCooldownLevel[0]);
                Debug.Log("shield max health " + shieldHealthLevel[0] + " shield cooldown " + shieldCooldownLevel[0]);
                break;
            case 2:
                _playerManager.IncreasedMaxShieldandDecreaseCooldown(shieldHealthLevel[1], shieldCooldownLevel[1]);
                Debug.Log("shield max health " + shieldHealthLevel[1] + " shield cooldown " + shieldCooldownLevel[1]);
                break;                
            case 3:
                _playerManager.IncreasedMaxShieldandDecreaseCooldown(shieldHealthLevel[2], shieldCooldownLevel[2]);
                Debug.Log("shield max health " + shieldHealthLevel[2] + " shield cooldown " + shieldCooldownLevel[2]);
                break;
        }
       
    }

    public void IncreaseShieldBuffLevel()
    {
        _shieldBuffLevel++;
    }
    #endregion

    #region Heal
    public void activateHealHealth(int healthToHeal)
    {
        _playerManager.healPlayer(healthToHeal);
        Debug.Log("activate heal");
    }
    #endregion
}
