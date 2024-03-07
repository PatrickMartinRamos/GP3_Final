using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCombatScript : MonoBehaviour
{
    bulletPool bulletPool;
    bulletManager _bulletManager;
    playerPowerUpManager _playerPowerUpManager;

    public Transform bulletSpawnPoint;

    private float lastShootTime;

    private void Start()
    {
        bulletPool = bulletPool._SharedInstance;
        _bulletManager = FindObjectOfType<bulletManager>();
        _playerPowerUpManager = GetComponent<playerPowerUpManager>();
    }

    private void Update()
    {
        if (Time.time - lastShootTime >= _bulletManager._bulletInterval)
        {
            shootBullet();
            shootScatterBullet();
            lastShootTime = Time.time;
        }
    }
    #region shoot bullet
    void shootBullet()
    {
        GameObject bullet = bulletPool.GetPooledObject();

        if (bullet != null)
        {
            bullet.transform.position = bulletSpawnPoint.transform.position;
            bullet.transform.rotation = bulletSpawnPoint.transform.rotation;
            bullet.SetActive(true);
        }
    }
    #endregion

    #region shootScatterBullet
    void shootScatterBullet()
    {
        // Check if the scatter bullet power-up is activated
        if (_playerPowerUpManager._scatterBullet_1)
        {
            // Instantiate a bullet at the position of _scatterBulletPOS_1
            GameObject bullet1 = bulletPool.GetPooledObject();
            if (bullet1 != null)
            {
                bullet1.transform.position = _playerPowerUpManager._scatterBulletPOS_1.position;
                bullet1.transform.rotation = _playerPowerUpManager._scatterBulletPOS_1.rotation;
                bullet1.SetActive(true);
            }
        }

        if (_playerPowerUpManager._scatterBullet_2)
        {
            // Instantiate a bullet at the position of _scatterBulletPOS_2
            GameObject bullet2 = bulletPool.GetPooledObject();
            if (bullet2 != null)
            {
                bullet2.transform.position = _playerPowerUpManager._scatterBulletPOS_2.position;
                bullet2.transform.rotation = _playerPowerUpManager._scatterBulletPOS_2.rotation;
                bullet2.SetActive(true);
            }
        }
    }
    #endregion

}
