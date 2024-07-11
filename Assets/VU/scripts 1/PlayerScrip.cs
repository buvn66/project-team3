using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private float moveInput;
    public float speed; // Tốc độ
    public float jumpForce = 5f; // Lực nhảy
    private bool isFacingRight = true; // Biến để xác định hướng của nhân vật
    private bool isGrounded; // Kiểm tra xem nhân vật có đang ở trên mặt đất không
    public Animator myAnim;
    public bool isAttacking = false;

    public static PlayerScript instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        myAnim = GetComponent<Animator>();
    }

    void Update()
    {
        HandleMovement();
        HandleJumping();
        Attack();
    }
    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.B) && !isAttacking)
        {
            isAttacking = true;
        }
    }
    // Phương thức xử lý di chuyển
    void HandleMovement()
    {
        moveInput = Input.GetAxis("Horizontal");
        Vector2 moveVelocity = new Vector2(moveInput * speed, rb.velocity.y);
        rb.velocity = moveVelocity;

        // Xác định hướng di chuyển và cập nhật hình dạng của nhân vật
        Flip();

        // Cập nhật animation
        bool isMoving = Mathf.Abs(moveInput) > 0.1f;
        anim.SetBool("ismove", isMoving);
    }

    // Phương thức để xử lý nhảy
    void HandleJumping()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false; // Đặt isGrounded thành false ngay khi nhảy lên
        }

        // Cập nhật animation cho nhảy
        //anim.SetBool("isJumping", !isGrounded);
    }

    // Phương thức để đảo ngược hình dạng của nhân vật
    void Flip()
    {
        if (isFacingRight && moveInput < 0 || !isFacingRight && moveInput > 0)
        {
            isFacingRight = !isFacingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    // Kiểm tra va chạm với mặt đất để đặt isGrounded thành true
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = false;
        }
    }
}
