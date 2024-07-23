using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] AudioClip pointPickUp;
    [SerializeField] float pointValue = 100;

    private bool isCollected = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isCollected = true;
            Object.FindObjectOfType<GameController>().AddScore((int)pointValue);
            AudioSource.PlayClipAtPoint(pointPickUp, Camera.main.transform.position);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
