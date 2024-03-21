using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationChecker : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Boss")
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            Vector3 initialLocation = collision.transform.position;
            enemy.MoveEnemy(Vector2.left);
            if (Vector2.Distance(transform.position, initialLocation) >= 2)
            {
                collision.gameObject.GetComponent<Enemy>().SetInPlaceStatus(true);
            }
        }
            
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            collision.gameObject.GetComponent<Enemy>().SetInPlaceStatus(false);
    }
}
