using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vungu : MonoBehaviour
{
    public float moveSpeed = 1f;
    private Transform playerTransform;

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject == null)
        {
            playerObject = FindObjectOfType<GameObject>();
        }
        if (playerObject != null)
        {
            playerTransform = playerObject.transform;
        }
        else
        {
            Debug.Log("no player");
        }
    }


    void Update()
    {
        if (playerTransform != null)
        {
            Vector3 diretion = (playerTransform.position - transform.position).normalized;
            transform.Translate(diretion * moveSpeed * Time.deltaTime);
        }
    }

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
