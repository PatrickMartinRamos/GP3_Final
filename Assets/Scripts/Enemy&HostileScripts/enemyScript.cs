using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    enemyManagerScript enemyManagerScript;

    private void Awake()
    {
        enemyManagerScript = GetComponentInParent<enemyManagerScript>();
    }

    private void Update()
    {
        transform.Translate(Vector3.left * enemyManagerScript.enemySpeed * Time.deltaTime);
        CheckIfOutsideViewport();
    }


    private void CheckIfOutsideViewport()
    {
        Vector3 viewportPos = Camera.main.WorldToViewportPoint(transform.position);

        // If the bullet is outside the viewport, set it false
        if (viewportPos.x < -0 || viewportPos.x > 2 || viewportPos.y < -2 || viewportPos.y > 2)
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }

}
