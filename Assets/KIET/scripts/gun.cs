using UnityEngine;

public class Gun : MonoBehaviour
{

    public GameObject bulletPrefab;  // Prefab của đạn
    public Transform firePoint;  // Vị trí bắn đạn
    public float bulletSpeed = 10f;  // Tốc độ của đạn
    public float fireRate = 2f;  // Tốc độ bắn (giây giữa mỗi lần bắn)

    private float fireTimer;  // Bộ đếm thời gian cho tốc độ bắn

    void Start()
    {
        fireTimer = fireRate;  // Khởi tạo bộ đếm thời gian
    }

    void Update()
    {
        fireTimer -= Time.deltaTime;  // Giảm bộ đếm thời gian theo thời gian đã trôi qua

        if (fireTimer <= 0f)
        {
            Shoot();  // Bắn đạn
            fireTimer = fireRate;  // Đặt lại bộ đếm thời gian
        }
    }

    void Shoot()
    {
        // Tạo một viên đạn từ prefab tại vị trí bắn
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        // Thêm lực đẩy cho viên đạn theo hướng firePoint với tốc độ bulletSpeed
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = firePoint.right * bulletSpeed;
        //huy viên đạn sao 2s
        Destroy(bullet,3f);
    }
}