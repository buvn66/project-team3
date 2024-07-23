using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostSpeed : MonoBehaviour
{
    [SerializeField] AudioClip pointPickUp;
    [SerializeField] float extraSpeedAmount = 5f; // Số liệu vận tốc tăng thêm khi chạm
    [SerializeField] float extraSpeedDuration = 2f; // Thời hạn đối tượng được tăng tốc

    private bool isCollected = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isCollected = true;
            AudioSource.PlayClipAtPoint(pointPickUp, Camera.main.transform.position);
            // Tăng tốc độ chạy của người chơi
            PlayerBiggani player = other.GetComponent<PlayerBiggani>();
            if (player != null)
            {
                player.ApplyExtraSpeed(extraSpeedAmount, extraSpeedDuration);
            }
            gameObject.SetActive(false); // Vô hiệu hóa đối tượng hiện tại
            Destroy(gameObject); // Hủy đối tượng trong hiệu ứng
        }
    }
}
