using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth;
    int currentHealth;
    public GameController GameController;
    public UnityEvent OnDeath;

    private void OnEnable()
    {
        OnDeath.AddListener(Death);
    }

    private void OnDisable()
    {
        OnDeath.RemoveListener(Death);
    }

    void Start()
    {
        currentHealth = maxHealth;
        GameController.UpdateBar(currentHealth, maxHealth);
    }

    public void TakeDame(int dame)
    {
        currentHealth -= dame;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            OnDeath.Invoke();
        }

        GameController.UpdateBar(currentHealth, maxHealth);
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Kiểm tra xem đối tượng va chạm có tag "Enemy" không
        if (other.CompareTag("Enemy"))
        {
            TakeDame(1); // Hoặc giá trị thiệt hại khác
        }

        // Kiểm tra xem đối tượng va chạm có tag "Hitbox" không
        if (other.CompareTag("hitbox"))
        {
            TakeDame(1); // Trừ 1 máu khi va chạm với đối tượng có tag "Hitbox"
        }
    }
}
