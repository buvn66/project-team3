using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private float moveInput;
    public float speed; // Tốc độ di chuyển
    public float jumpForce = 5f; // Lực nhảy
    private bool isFacingRight = true; // Biến để xác định hướng của nhân vật
    private bool isGrounded; // Kiểm tra xem nhân vật có đang ở trên mặt đất không
    public Animator myAnim;
    public bool isAttacking = false;
    public GameObject attackPoint; // Điểm tấn công
    public float radius; // Bán kính tấn công
    public LayerMask enemies; // Layer của đối tượng quân địch
    public float damage;
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 5f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    [SerializeField] private TrailRenderer tr;

    // Thêm biến để lưu âm thanh nhảy
    public AudioClip jumpSound;
    private AudioSource audioSource;

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
        audioSource = GetComponent<AudioSource>(); // Lấy thành phần AudioSource
    }

    void Update()
    {
        if (isDashing)
        {
            return;
        }
        HandleMovement();
        HandleJumping();

        // Xử lý tấn công khi nhấn chuột trái
        if (Input.GetMouseButtonDown(0) && !isAttacking)
        {
            isAttacking = true;
            myAnim.SetBool("Attack", true); // Kích hoạt animation tấn công
            Attack(); // Gọi hàm xử lý tấn công
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }

        // Cập nhật animation di chuyển
        UpdateAnimation();
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
    }

    // Phương thức tấn công
    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.transform.position, radius, enemies);
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("Hit enemy: " + enemy.name);
            Enemyheath enemyHeath = enemy.GetComponent<Enemyheath>();
            if (enemyHeath != null)
            {
                enemyHeath.heath -= damage; // Trừ đi lượng máu của kẻ thù
            }
        }
    }

    // Phương thức kết thúc animation tấn công
    public void EndAttack()
    {
        isAttacking = false;
        myAnim.SetBool("Attack", false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.transform.position, radius);
    }

    // Cập nhật animation di chuyển
    void UpdateAnimation()
    {
        bool isMoving = Mathf.Abs(moveInput) > 0.1f;
        anim.SetBool("ismove", isMoving);
    }

    // Phương thức xử lý di chuyển
    void HandleMovement()
    {
        moveInput = Input.GetAxis("Horizontal");
        Vector2 moveVelocity = new Vector2(moveInput * speed, rb.velocity.y);
        rb.velocity = moveVelocity;

        // Xác định hướng di chuyển và cập nhật hình dạng của nhân vật
        Flip();
    }

    // Phương thức xử lý nhảy
    void HandleJumping()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false; // Đặt isGrounded thành false ngay khi nhảy lên
        }
    }

    // Phương thức đảo ngược hình dạng của nhân vật
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

    // Phương thức va chạm với mặt đất để đặt isGrounded thành true và phát âm thanh nhảy
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
            audioSource.PlayOneShot(jumpSound); // Phát âm thanh nhảy khi chạm đất
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = false;
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
