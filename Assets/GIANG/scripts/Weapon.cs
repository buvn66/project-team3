using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private bool playerInRange = false;
    private bool canPickUp = false;
    public GameObject weaponInfoCanvas;
    public float displayTime = 10f;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            canPickUp = true;
            StartCoroutine(ShowCanvasForTime()); // Bắt đầu Coroutine để hiển thị Canvas và tự động đóng lại
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            canPickUp = false;
            if (weaponInfoCanvas != null)
            {
                weaponInfoCanvas.SetActive(false); // Ẩn Canvas khi người chơi đi ra khỏi phạm vi
            }
        }
    }
    IEnumerator ShowCanvasForTime()
    {
        // Hiển thị Canvas
        if (weaponInfoCanvas != null)
        {
            weaponInfoCanvas.SetActive(true);
        }

        // Đợi displayTime giây
        yield return new WaitForSeconds(displayTime);

        // Sau đó ẩn Canvas
        if (weaponInfoCanvas != null)
        {
            weaponInfoCanvas.SetActive(false);
        }
    }
    void Update()
    {
        if (playerInRange && canPickUp)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                PickUpWeapon();
            }
        }
    }
    void PickUpWeapon()
    {
        Destroy(gameObject);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBiggani>().ShowCurrentWeapon();
    }
}