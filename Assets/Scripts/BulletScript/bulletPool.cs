using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletPool : MonoBehaviour
{
    // eto ginamit ko na guide para sa pooling check nyo nlng if my problem -pat
    //https://www.kodeco.com/847-object-pooling-in-unity

    //public var
    public static bulletPool _SharedInstance;
    public List<GameObject> _pooledBullets;
    public GameObject _bulletToPool;
    public int _amountToPool;

    private void Awake()
    {
        _SharedInstance = this;
    }

    private void Start()
    {
        _pooledBullets = new List<GameObject>();
        for(int i = 0; i < _amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(_bulletToPool);
            obj.SetActive(false);
            _pooledBullets.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < _pooledBullets.Count; i++)
        {
            if (!_pooledBullets[i].activeInHierarchy)
            {
                return _pooledBullets[i];
            }
        }
        return null;
    }
}
