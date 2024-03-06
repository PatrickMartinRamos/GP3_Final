using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManagerScript : MonoBehaviour
{
    public static playerManagerScript _playerManagerInstance;

    //public var
    public int _maxHealth;
    public int _playerCurrentHealth;
    public float playerMoveSpeed = 10f;

    public int currencyEarned; //dito ko muna lagay pero lipat naten sa enemy pag na destroy

    public void Awake()
    {
        _playerManagerInstance = this;
    }

    private void Start()
    {
        _playerCurrentHealth = _maxHealth;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            int damage = 1; //place holder muna para sa enemy damage

            _playerCurrentHealth -= damage; // dpat enemy damage - sa player current health

            currencyEarned++; //add currency para sa shop naten
            Debug.Log("Player hit");
            Destroy(collision.gameObject); 
        }
    }
}
