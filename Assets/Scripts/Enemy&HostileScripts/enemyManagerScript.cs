using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemyManagerScript : MonoBehaviour
{
    /// <summary>
    /// dito lagay ung speed, damage to player etc
    /// </summary>

    //public var
    public int enemyHealth;
    public int enemyDamage;
    public float enemySpeed;

    private void Update()
    {
        // Check if all child objects are inactive
        bool allChildrenInactive = true;
        foreach (Transform child in transform)
        {
            if (child.gameObject.activeSelf)
            {
                allChildrenInactive = false;
                break;
            }
        }

        // If all children are inactive, destroy this object
        if (allChildrenInactive)
        {
            Destroy(gameObject);
        }
    }
}
