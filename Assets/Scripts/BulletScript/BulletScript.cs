using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    bulletManager _bulletManager;
    // Update is called once per frame
    private void Start()
    {
        _bulletManager = FindObjectOfType<bulletManager>();
    }

    void Update()
    {
        transform.Translate(Vector2.right * _bulletManager._bulletSpeed * Time.deltaTime);
        CheckIfOutsideViewport();
    }

    private void CheckIfOutsideViewport()
    {
        Vector3 viewportPos = Camera.main.WorldToViewportPoint(transform.position);

        // If the bullet is outside the viewport, set it false
        if (viewportPos.x < 0 || viewportPos.x > 1 || viewportPos.y < 0 || viewportPos.y > 1)
        {
            gameObject.SetActive(false);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Boss"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            enemy.Damage(_bulletManager._bulletDamage);

           
            gameObject.SetActive(false);
        }
    }
    
}
