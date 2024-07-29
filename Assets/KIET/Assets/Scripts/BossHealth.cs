using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public int health = 100;
    public bool isInvulnerable = false;

    public Slider healthSlider; // Thêm biến tham chiếu đến thanh trượt
    private Animator animator; // Thêm biến Animator

    private void Start()
    {
        healthSlider.maxValue = health;
        healthSlider.value = health;
        animator = GetComponent<Animator>(); // Lấy component Animator
    }

    public void TakeDamage(int damage)
    {
        if (isInvulnerable)
            return;

        health -= damage;
        healthSlider.value = health; // Cập nhật thanh trượt

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetTrigger("Death"); // Kích hoạt animation chết
        StartCoroutine(HandleDeath()); // Gọi coroutine để xử lý cái chết
        animator.SetTrigger("isDead"); // Kích hoạt animation chết
        StartCoroutine(HandleDeath()); // Gọi coroutine để xử lý cái chết
    }

    private IEnumerator HandleDeath()
    {
        yield return new WaitForSeconds(1f); // Thay đổi thời gian nếu cần, để phù hợp với độ dài animation
        
        Destroy(gameObject); // Hủy đối tượng boss
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            TakeDamage(10);
            Destroy(other.gameObject); // Hủy viên đạn sau khi bắn
        }
    }
}
