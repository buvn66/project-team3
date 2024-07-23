using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth;
    int currentHealth;
    public HealthBar healthBar;

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

        healthBar.UpdateBar(currentHealth, maxHealth);
    }

    public void TakeDame(int dame)
    {
        currentHealth -= dame;

        if (currentHealth < 0)
        {
            currentHealth = 0;
            OnDeath.Invoke();
        }

        healthBar.UpdateBar(currentHealth, maxHealth);
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            TakeDame(20);
        }
    }
}
