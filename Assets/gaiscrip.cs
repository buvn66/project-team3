using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gaiscrip : MonoBehaviour
{
    // Tham chiếu đến component PlayerHealth
    private PlayerHealth playerHealth;

    // Thay đổi các biến liên quan đến giảm máu liên tục
    public int damageAmount = 2; // Số lượng máu giảm mỗi giây
    public float damageInterval = 1f; // Khoảng thời gian giữa các lần giảm máu
    private bool isDamaging = false; // Kiểm tra xem có đang giảm máu không

    private void Start()
    {
        // Lấy component PlayerHealth (giả sử script này gắn với cùng đối tượng hoặc một đối tượng khác)
        playerHealth = FindObjectOfType<PlayerHealth>();

        // Kiểm tra xem PlayerHealth có tồn tại không
        if (playerHealth == null)
        {
            Debug.LogError("PlayerHealth component not found.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Kiểm tra xem đối tượng va chạm có phải là nhân vật người chơi không
        if (other.CompareTag("Player"))
        {
            // Bắt đầu giảm máu liên tục nếu chưa bắt đầu
            if (!isDamaging)
            {
                isDamaging = true;
                StartCoroutine(DamagePlayer(other.GetComponent<PlayerHealth>()));
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Dừng giảm máu khi nhân vật rời khỏi vùng va chạm
        if (other.CompareTag("Player"))
        {
            isDamaging = false;
        }
    }

    private IEnumerator DamagePlayer(PlayerHealth playerHealth)
    {
        // Giảm máu liên tục
        while (isDamaging && playerHealth != null)
        {
            playerHealth.TakeDame(damageAmount);
            yield return new WaitForSeconds(damageInterval);
        }
    }
}
