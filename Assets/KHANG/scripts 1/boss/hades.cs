using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hades : MonoBehaviour
{
    public int health;

    public Slider healthBar;
    // Tốc độ di chuyển của boss  
    public float speed = 5f;
    // Khoảng cách dừng khi boss tới gần Player
    public float stoppingDistance = 1.5f;
    // Transform của Player
    private Transform player;
    [SerializeField]
    private float jumpForce = 10f;

    private Rigidbody2D _rb;


    private void Start()
    {
        // Tìm đối tượng có tag "Player" và lấy Transform của nó
        player = GameObject.FindGameObjectWithTag("Player").transform;
        _rb = GetComponent<Rigidbody2D>();
        StartCoroutine(JumpRoutine());
    }

    private void Update()
    {                      
        // Kiểm tra nếu player không null
        if (player != null)
        {
            // Tính khoảng cách giữa boss và player
            float distance = Vector3.Distance(transform.position, player.position);

            // Nếu khoảng cách lớn hơn khoảng cách dừng, boss sẽ di chuyển về phía player
            if (distance > stoppingDistance)
            {
                // Tính toán vector hướng tới player
                Vector3 direction = (player.position - transform.position).normalized;

                // Di chuyển boss theo hướng đó
                transform.position += direction * speed * Time.deltaTime;                
            }
        }
    }
    private IEnumerator JumpRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);  // Đợi 1 giây
            Jump();
        }
    }

    private void Jump()
    {
        // Áp dụng lực nhảy cho đối tượng Knight
        _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
