using System.Collections.Generic;
using UnityEngine;

public class bulletPool : MonoBehaviour
{
    public static bulletPool _SharedInstance;

    public List<GameObject> _pooledBullets;
    public List<GameObject> _pooledWispBullets;
    public GameObject _bulletToPool;
    public GameObject _wispBulletToPool;
    public int _amountToPool;
    public int _amountToPoolWisp; // New variable for wisp bullet pool size

    private void Awake()
    {
        _SharedInstance = this;
    }

    private void Start()
    {
        _pooledBullets = new List<GameObject>();
        _pooledWispBullets = new List<GameObject>();

        // Pool regular bullets
        for (int i = 0; i < _amountToPool; i++)
        {
            GameObject obj = Instantiate(_bulletToPool);
            obj.SetActive(false);
            _pooledBullets.Add(obj);
        }

        // Pool wisp bullets
        for (int i = 0; i < _amountToPoolWisp; i++) // Use _amountToPoolWisp for wisp bullets
        {
            GameObject obj = Instantiate(_wispBulletToPool);
            obj.SetActive(false);
            _pooledWispBullets.Add(obj);
        }
    }

    public GameObject GetPooledObject(bool isWisp = false)
    {
        if (!isWisp)
        {
            for (int i = 0; i < _pooledBullets.Count; i++)
            {
                if (!_pooledBullets[i].activeInHierarchy)
                {
                    return _pooledBullets[i];
                }
            }
        }
        else
        {
            for (int i = 0; i < _pooledWispBullets.Count; i++)
            {
                if (!_pooledWispBullets[i].activeInHierarchy)
                {
                    return _pooledWispBullets[i];
                }
            }
        }
        return null;
    }
}
