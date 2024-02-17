using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCombatScript : MonoBehaviour
{
    bulletPool bulletPool;
    public Transform bulletSpawnPoint;
    public float shootInterval = 2.5f; // Adjust this value to set the interval between shots

    private float lastShootTime;

    private void Start()
    {
        bulletPool = bulletPool._SharedInstance;
    }

    private void Update()
    {
        if (Time.time - lastShootTime >= shootInterval)
        {
            shootBullet();
            lastShootTime = Time.time;
        }
    }

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
}
