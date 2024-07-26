using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private Rigidbody2D _rigidbody; // Rigidbody 2D: Vật lý

    private BoxCollider2D _boxCollider2D; // Collider 2D: Va chạm

    public GameObject bulletPrefab; // Prefab của đạn

    public Transform firePoint; // Vị trí bắn đạn

    public float bulletForce = 20f; // Lực đẩy của đạn

    private Animator _animator; // Animator của Enemy

    public float fireRate = 5.0f; // Tốc độ bắn (số lần bắn mỗi giây)

    private float nextFireTime = 0f; // Thời gian tiếp theo có thể bắn

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _animator = GetComponent<Animator>();

        // Đặt nextFireTime ban đầu
        nextFireTime = Time.time;
    }

    void Update()
    {
        // Kiểm tra xem có thể bắn đạn hay không
        if (CanSeePlayer() && Time.time > nextFireTime)
        {
            // Cập nhật thời gian tiếp theo có thể bắn
            nextFireTime = Time.time + 1f / fireRate;

            // Gọi coroutine AttackCoroutine
            StartCoroutine(AttackCoroutine());
        }
    }

    private bool CanSeePlayer()
    {
        return true; // Giả sử luôn có thể nhìn thấy Player
    }

    IEnumerator AttackCoroutine()
    {
        // Kích hoạt animation attack
        _animator.SetTrigger("attack");

        // Đợi cho đến khi animation attack kết thúc
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length - 0.01f);

        // Sau khi animation attack kết thúc, kiểm tra xem Enemy có thể bắn không
        if (CanSeePlayer())
        {
            Shoot(); // Bắn đạn
        }
    }

    void Shoot()
    {
        if (bulletPrefab && firePoint)
        {
            Vector2 shootDirection = -firePoint.right; // Hướng bắn từ phải qua trái

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            if (rb)
            {
                rb.AddForce(shootDirection.normalized * bulletForce, ForceMode2D.Impulse); // Đảm bảo hướng bắn luôn được chuẩn hóa
            }

            Destroy(bullet, 1.0f); // Hủy đạn sau 1 giây
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}
