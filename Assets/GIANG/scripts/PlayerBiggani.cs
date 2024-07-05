using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBiggani : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    public Vector3 moveInput;

    private Animator animator;

    public float dashBoost = 2f;
    private float dashTime;
    public float DashTime;
    private bool once;
    public GameObject currentWeapon;

    public HealthBar playerHealth; // Reference to the HealthBar script

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerHealth = GetComponent<HealthBar>(); // Assuming HealthBar is attached to the same GameObject
    }

    private void Update()
    {
        // Movement
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        rb.velocity = moveInput.normalized * moveSpeed;

        // Animation
        animator.SetFloat("Speed", moveInput.sqrMagnitude);

        // Dash
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashTime <= 0)
        {
            animator.SetBool("Dash", true);
            moveSpeed += dashBoost;
            dashTime = DashTime;
            once = true;
        }

        if (dashTime <= 0 && once)
        {
            animator.SetBool("Dash", false);
            moveSpeed -= dashBoost;
            once = false;
        }
        else
        {
            dashTime -= Time.deltaTime;
        }

        // Flip character based on movement direction
        if (moveInput.x != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(moveInput.x), 1, 1);
        }

        // Attack (assuming Mouse0 is left mouse button)
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetBool("DanhTay", true);
            // Logic for attacking (e.g., dealing damage to enemies)
            Attack();
        }
        else
        {
            animator.SetBool("DanhTay", false);
        }
    }

    void Attack()
    {
        // Placeholder logic for attacking
        // You can add more sophisticated logic here (e.g., check for enemies in range)
        Debug.Log("Attacking!");

        // Example: If there's a current weapon, show it
        ShowCurrentWeapon();
    }

    // Function to show the current weapon (you might need to adjust this based on your game logic)
    public void ShowCurrentWeapon()
    {
        if (currentWeapon != null)
        {
            currentWeapon.SetActive(true); // Show the current weapon
            currentWeapon = null; // Clear the reference to prevent showing it again
        }
    }

    // Function to take damage
    public void TakeDamage(int damage)
    {
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage); // Call the TakeDamage function of the HealthBar
        }
    }
}