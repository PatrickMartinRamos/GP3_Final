using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManagerScript : MonoBehaviour
{
    public static playerManagerScript _playerManagerInstance;
    public playerPowerUpManager _powerUpManager;

    //public var
    [Header("Health")]
    public int _maxHealth;
    public int _playerCurrentHealth;

    [Header("Shield")]
    public int _playerMaxShield;
    public int _playerCurrentShield;
    public float _shieldCooldown;
    public float _shieldColliderRadius;
    public bool isUsingShield = false;
    public bool isShieldCooldown = false;
    private Coroutine shieldCooldownCoroutine;

    [Header("Move Speed")]
    public float playerMoveSpeed = 10f; 

    private CircleCollider2D circleCollider;
    private float _originalShieldRadius = 7f;
    public void Awake()
    {
        _playerManagerInstance = this;

        _playerCurrentHealth = _maxHealth;
        _playerCurrentShield = _playerMaxShield;
    }

    private void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        switchToShield();
        shieldCooldown();
    }

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

        if(_playerCurrentShield <= 0)
        {
            isUsingShield = false;
        }
    }
    /// <summary>
    /// di gumagana ung cooldown paki ayos pag uwe thnks
    /// </summary>
    void shieldCooldown()
    {
        if (_playerCurrentShield < _playerMaxShield && !isShieldCooldown)
        {
            isShieldCooldown = true;
            StartCoroutine(shieldCooldownTimer());
        }
    }
    public void IncreaseMaxHealth(int healthToAdd)
    {
        _maxHealth += healthToAdd;
        _playerCurrentHealth += healthToAdd; //reset ung current health pag bumili ng max health power up
    }
    public void IncreasedMaxShield(int shieldMaxHealth, int shieldCooldown)
    {
        _playerMaxShield += shieldMaxHealth;
        _playerCurrentShield += shieldMaxHealth; //reset ung current health pag bumili ng shield power up

        _shieldCooldown = shieldCooldown;
    }
    IEnumerator shieldCooldownTimer()
    {
        while (isShieldCooldown)
        {
            yield return new WaitForSeconds(_shieldCooldown);

            _playerCurrentShield = Mathf.Min(_playerCurrentShield + 1);

            // Shield cooldown is over
            isShieldCooldown = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int damage = collision.gameObject.GetComponent<Enemy>().enemyDamage; //place holder muna para sa enemy damage

        if (collision.collider.CompareTag("Enemy"))
        {
            if (!isUsingShield)
            {             
                _playerCurrentHealth -= damage; // dpat enemy damage - sa player current health
                Debug.Log("collide with player");
                Destroy(collision.gameObject);
            }
            else
            {
                _playerCurrentShield -= damage;
                Debug.Log("collide with shield");
                Destroy(collision.gameObject);
            }

        }
    }


}
