using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.Animations;

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
    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    private void Update()
    {
        //di chuyển
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        transform.position += moveSpeed * Time.deltaTime * moveInput;

        //animation
        animator.SetFloat("Speed", moveInput.sqrMagnitude);

        //dash
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

        if (moveInput.x != 0)
        {
            if (moveInput.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 0);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 0);
            }
        }
        //danh tay
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetBool("DanhTay", true);
        }
        else
        {
            animator.SetBool("DanhTay", false);
        }
    }

    public void ShowCurrentWeapon()
    {
        if (currentWeapon != null)
        {
            currentWeapon.SetActive(true); // Hiển thị vũ khí có sẵn
            currentWeapon = null; // Xóa reference để ngăn cản việc hiển thị lại
        }
    }

    public PlayerHealth playerHealth;
    public void TakeDamage(int damage)
    {
        playerHealth.TakeDame(damage);
    }

    //Boots Speed
    public void ApplyExtraSpeed(float speedBoost, float duration)
    {
        StartCoroutine(ExtraSpeedCoroutine(speedBoost, duration));
    }

    private IEnumerator ExtraSpeedCoroutine(float speedBoost, float duration)
    {
        // Tăng tốc độ
        moveSpeed += speedBoost;

        // Chờ đợi cho đến khi hết thời hạn
        yield return new WaitForSeconds(duration);

        // Giảm tốc độ trở lại như ban đầu
        moveSpeed -= speedBoost;
    }
    
}