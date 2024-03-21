using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManagerScript : MonoBehaviour
{
    public static playerManagerScript _playerManagerInstance;
    public playerPowerUpManager _powerUpManager;
    public SceneChange sceneChange;
    public musicManager musicManager;
    #region health
    //public var
    [Header("Health")]
    public int _maxHealth;
    public int _playerCurrentHealth;
    #endregion

    #region Shield
    [Header("Shield")]
    public int _playerMaxShield;
    public int _playerCurrentShield;
    public float _shieldColliderRadius;
    public bool isUsingShield = false;
    public bool isShieldCooldown = false;
    public float _shieldCooldown;
    public GameObject shieldObject;
    [HideInInspector]public float timeSinceShieldDamage = 0f;
    #endregion

    #region player move speed
    [Header("Move Speed")]
    public float playerMoveSpeed = 10f;
    #endregion

    #region collider2D
    private CircleCollider2D circleCollider;
    private float _originalShieldRadius = 7f;
    #endregion

    #region update/start/awake
    public void Awake()
    {
        _playerManagerInstance = this;

        _playerCurrentHealth = _maxHealth;
        _playerCurrentShield = _playerMaxShield;
    }
  
    private void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        sceneChange = FindObjectOfType<SceneChange>();
        musicManager = FindObjectOfType<musicManager>();
    }

    private void Update()
    {
        switchToShield();
        startShieldCooldown();
        gameOver();
        handleShieldState();
    }
    #endregion

    #region shield logic
    void switchToShield()
    {      
        if(isUsingShield)
        {
            circleCollider.radius = _shieldColliderRadius;
        }
        else
        {
            circleCollider.radius = _originalShieldRadius;
        }

    }
    void handleShieldState()
    {
        if (_playerCurrentShield <= 0)
        {
            _powerUpManager._shieldBuffObject.SetActive(false);
        }
        else
        {
            _powerUpManager._shieldBuffObject.SetActive(true);
        }
    }

    public void startShieldCooldown()
    {
        if (isUsingShield && _playerCurrentShield < _playerMaxShield)
        {
            timeSinceShieldDamage += Time.deltaTime;
            if (timeSinceShieldDamage >= _shieldCooldown)
            {
                timeSinceShieldDamage = 0f;
                RegenerateShield();
            }
            isShieldCooldown = true; // Set isShieldCooldown to true when shield is regenerating
        }
        else
        {
            isShieldCooldown = false; // Set isShieldCooldown to false when shield is not regenerating
        }
    }

    void RegenerateShield()
    {
        if (_playerCurrentShield < _playerMaxShield)
        {
            _playerCurrentShield++;
        }
        else
        {
           timeSinceShieldDamage = 0f;
        }
    }

    #endregion

    #region increase max health and increase max shield/decrease shield cooldown
    public void IncreaseMaxHealth(int healthToAdd)
    {
        _maxHealth += healthToAdd;
        _playerCurrentHealth += healthToAdd; //reset ung current health pag bumili ng max health power up
    }
    public void IncreasedMaxShieldandDecreaseCooldown(int shieldMaxHealth, int shieldCooldown)
    {
        _playerMaxShield += shieldMaxHealth;
        _playerCurrentShield += shieldMaxHealth; //reset ung current health pag bumili ng shield power up

        _shieldCooldown = shieldCooldown;
    }
    #endregion

    #region
    public void healPlayer(int healthToHeal)
    {
        _playerCurrentHealth += healthToHeal;

        // Check if the current health exceeds the maximum health
        if (_playerCurrentHealth > _maxHealth)
        {
            _playerCurrentHealth = _maxHealth; // Set current health to maximum health if it exceeds
        }
    }
    #endregion

    #region handle enemy collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        int damage = collision.gameObject.GetComponent<Enemy>().enemyDamage; //place holder muna para sa enemy damage

        if (collision.collider.CompareTag("Enemy"))
        {
            if (!isUsingShield || _playerCurrentShield <= 0) 
            {             
                _playerCurrentHealth -= damage;
                Debug.Log("collide with player");
                collision.gameObject.GetComponent<Enemy>().Die();
                musicManager.playHitPlayerSFX();
            }
            else
            {
                _playerCurrentShield -= damage;
                isShieldCooldown = true;
                Debug.Log("collide with shield");
                collision.gameObject.GetComponent<Enemy>().Die();
                musicManager.shieldHitPlayerSFX();
            }
        }

        if (collision.collider.CompareTag("Boss"))
        {
            if (!isUsingShield || _playerCurrentShield <= 0)
            {
                _playerCurrentHealth -= damage;
                Debug.Log("Boss collided with player");
                musicManager.playHitPlayerSFX();
            }
            else
            {
                _playerCurrentShield -= damage;
                isShieldCooldown = true;
                Debug.Log("Boss collided with shield");
                musicManager.shieldHitPlayerSFX();
            }
        }
    }

    void gameOver()
    {
        if(_playerCurrentHealth <= 0)
        {
            Debug.Log("Game Over");
            sceneChange.loadMainMenu();
        }

    }
    #endregion
}
