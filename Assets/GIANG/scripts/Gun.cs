using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public Transform FirePos;
    public float FireForce = 1.0f; // Lực bắn của viên đạn
    public float cooldownTime = 0.5f; // Thời gian giữa mỗi lần bắn
    public float MoveSpeed = 5.0f; // Tốc độ di chuyển của súng tới người chơi
    public Transform player; // Đối tượng người chơi

    private float cooldownTimer;

    void Start()
    {
        // Tìm và lưu đối tượng người chơi (Player)
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (player == null)
        {
            Debug.LogError("Player transform not found!");
        }

        cooldownTimer = 0f; // Khởi động cooldown
    }

    void Update()
    {
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }

        AutoFire(); // Tự động bắn theo enemy
        FollowPlayer(); // Tự động đi theo người chơi
    }

    void AutoFire()
    {
        // Kiểm tra cooldown trước khi bắn
        if (cooldownTimer > 0)
            return;

        // Tìm tất cả các enemy trong phạm vi
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length == 0)
        {
            // Không có enemy, không thực hiện bắn
            return;
        }
        else
        {
            // Có enemy, tiến hành bắn
            // Chỉ nhắm vào enemy gần nhất (enemies[0])
            Vector3 targetDir = enemies[0].transform.position - FirePos.position;
            float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(0, 0, angle);

            // Áp dụng hướng xoay cho súng
            transform.rotation = rotation;

            // Kiểm tra hướng quay của súng để điều chỉnh scale
            if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
                transform.localScale = new Vector3(1, -1, 1);
            else
                transform.localScale = new Vector3(1, 1, 1);

            // Bắn đạn
            GameObject BulletTmp = Instantiate(bullet, FirePos.position, rotation);
            Rigidbody2D rb = BulletTmp.GetComponent<Rigidbody2D>();
            rb.AddForce(BulletTmp.transform.right * FireForce, ForceMode2D.Impulse);

            // Đặt lại cooldown
            cooldownTimer = cooldownTime;
        }
    }

    void FollowPlayer()
    {
        // Di chuyển súng tới vị trí của người chơi
        if (player != null)
        {
            Vector3 targetPos = player.position;
            targetPos.z = 0; // Chỉnh lại vị trí Z để nằm trên mặt phẳng của súng

            // Tính toán hướng di chuyển và di chuyển súng
            Vector3 moveDir = (targetPos - transform.position).normalized;
            transform.position += moveDir * MoveSpeed * Time.deltaTime;
        }
    }
}
