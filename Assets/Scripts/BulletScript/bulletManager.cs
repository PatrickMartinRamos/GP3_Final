using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletManager : MonoBehaviour
{
    public int _bulletDamage;
    public float _bulletSpeed = 10f;
    public float _bulletInterval = 2.5f;


    public void increasedBulletDamage(int damageBuffToAdd)
    {
        _bulletDamage += damageBuffToAdd;
    }
}
