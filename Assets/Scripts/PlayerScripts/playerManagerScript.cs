using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManagerScript : MonoBehaviour
{
    public static playerManagerScript _playerManagerInstance;

    //public var
    public float playerHealth;
    public float playerMoveSpeed = 10f;

    public void Awake()
    {
        _playerManagerInstance = this;
    }
}
