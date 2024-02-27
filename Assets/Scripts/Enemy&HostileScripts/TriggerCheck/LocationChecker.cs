using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationChecker : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            collision.gameObject.GetComponent<Enemy>().SetInPlaceStatus(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            collision.gameObject.GetComponent<Enemy>().SetInPlaceStatus(false);
    }
}
