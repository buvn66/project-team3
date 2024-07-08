using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private bool playerInRange = false;
    private bool canPickUp = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            canPickUp = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            canPickUp = false;
        }
    }

    void OnGUI()
    {
        if (playerInRange && canPickUp)
        {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2, 100, 20), "Press F to pick up");
        }
    }

    void Update()
    {
        if (playerInRange && canPickUp && Input.GetKeyDown(KeyCode.F))
        {
            PickUpWeapon();
        }
    }

    void PickUpWeapon()
    {
        // Xóa vũ khí hiện tại từ hierarchy
        Destroy(gameObject);

        // Hiển thị vũ khí có sẵn trên hierarchy (ví dụ: sử dụng PlayerController để trigger hiển thị vũ khí)
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBiggani>().ShowCurrentWeapon();
    }
}
