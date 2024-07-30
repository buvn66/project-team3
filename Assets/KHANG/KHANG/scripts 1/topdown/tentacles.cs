using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tentacles : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.SetActive(false);
        }
        if (collision.tag == "bullet")
        {
            Destroy(gameObject);
        }
    }
}
