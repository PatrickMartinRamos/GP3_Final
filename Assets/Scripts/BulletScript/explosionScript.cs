using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionScript : MonoBehaviour
{

    public playerPowerUpManager _playerPowerUPManager;

    private void Start()
    {
        _playerPowerUPManager = FindObjectOfType<playerPowerUpManager>();
    }
    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Particle collided with an enemy: " + other.name);

            Enemy enemy = other.GetComponent<Enemy>();

            enemy.Damage(_playerPowerUPManager._explosionDamage);
        }
    }
}
