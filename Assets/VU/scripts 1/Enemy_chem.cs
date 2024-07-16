using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_chem : MonoBehaviour
{
    #region Biến công khai
    public Transform rayCast; // Điểm bắt đầu của tia raycast
    public LayerMask raycastMask; // Lớp mặt nạ để kiểm tra va chạm của raycast
    public float rayCastLength; // Chiều dài của tia raycast
    public float attackDistance; // Khoảng cách tấn công của kẻ thù
    public float followDistance; // Khoảng cách để theo dõi người chơi
    public float moveSpeed; // Tốc độ di chuyển của kẻ thù
    public float timer; // Thời gian làm mát (cooldown) cho tấn công
    public Transform leftLimit;
    public Transform rightLimit;
    #endregion

    #region Biến riêng
    private RaycastHit2D hit; // Đối tượng lưu thông tin về va chạm của raycast
    private Transform target; // Mục tiêu (người chơi)
    private Animator anim; // Bộ điều khiển hoạt hình của kẻ thù
    private float distance; // Khoảng cách đến mục tiêu
    private bool attackMode; // Chế độ tấn công
    private bool inRange; // Biến kiểm tra xem người chơi có trong phạm vi hay không
    private bool cooling; // Biến kiểm tra xem kẻ thù có đang trong thời gian làm mát hay không
    private float intTimer; // Biến lưu trữ giá trị thời gian làm mát ban đầu
    #endregion 

    private void Awake()
    {
        SelectTarget();
        intTimer = timer; // Khởi tạo thời gian làm mát
        anim = GetComponent<Animator>(); // Lấy bộ điều khiển hoạt hình từ đối tượng
    }

    void Update()
    {
        if (!attackMode)
        {
            Move();
        }

        if (!InsideOfLimits() && !inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("Enemy_attack"))
        {
            SelectTarget();
        }

        if (inRange) // Nếu người chơi trong phạm vi
        {
            hit = Physics2D.Raycast(rayCast.position, transform.right, rayCastLength, raycastMask); // Phát ra tia raycast để kiểm tra va chạm với người chơi
            RaycastDebugger(); // Gọi hàm để hiển thị tia raycast trong chế độ phát triển
            // Khi phát hiện người chơi
            if (hit.collider != null)
            {
                EnemyLogic(); // Thực hiện logic của kẻ thù
            }
            else if (hit.collider == null)
            {
                inRange = false; // Nếu không có va chạm, người chơi không còn trong phạm vi
            }
            if (!inRange == false)
            {
                StopAttack(); // Dừng tấn công
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "Player") // Nếu đối tượng va chạm có tag "Player"
        {
            target = trig.transform; // Thiết lập mục tiêu là người chơi
            inRange = true; // Đặt biến inRange thành true
            Flip();
        }
    }

    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.position); // Tính khoảng cách đến người chơi
        if (distance > attackDistance)
        {
            StopAttack(); // Dừng tấn công
        }
        else if (distance <= attackDistance && !cooling)
        {
            Attack(); // Nếu trong phạm vi tấn công và không đang làm mát, tấn công người chơi
        }
        if (cooling)
        {
            anim.SetBool("Attack", false); // Nếu đang làm mát, tắt hoạt hình tấn công
        }
    }

    void Move()
    {
        anim.SetBool("canWalk", true); // Bật hoạt hình đi bộ

        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Skel_attack"))
        {
            Vector2 targetPosition = new Vector2(target.position.x, transform.position.y); // Chỉ di chuyển theo trục x
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime); // Di chuyển về phía người chơi với tốc độ ổn định
        }
    }

    void Attack()
    {
        timer = intTimer; // Đặt lại thời gian làm mát khi người chơi vào phạm vi tấn công
        attackMode = true; // Đặt chế độ tấn công thành true

        anim.SetBool("canWalk", false); // Tắt hoạt hình đi bộ
        anim.SetBool("Attack", true); // Bật hoạt hình tấn công
    }

    void StopAttack()
    {
        cooling = false; // Đặt biến cooling thành false
        attackMode = false; // Đặt chế độ tấn công thành false
        anim.SetBool("Attack", false); // Tắt hoạt hình tấn công
    }

    void RaycastDebugger()
    {
        if (distance > attackDistance)
        {
            Debug.DrawRay(rayCast.position, transform.right * rayCastLength, Color.red); // Hiển thị tia raycast màu đỏ nếu khoảng cách lớn hơn khoảng cách tấn công
        }
        else if (distance <= attackDistance)
        {
            Debug.DrawRay(rayCast.position, transform.right * rayCastLength, Color.green); // Hiển thị tia raycast màu xanh nếu khoảng cách nhỏ hơn hoặc bằng khoảng cách tấn công
        }
    }

    private bool InsideOfLimits()
    {
        return transform.position.x > leftLimit.position.x && transform.position.x < rightLimit.position.x;
    }

    private void SelectTarget()
    {
        float distanceToLeft = Vector2.Distance(transform.position, leftLimit.position);
        float distanceToRight = Vector2.Distance(transform.position, rightLimit.position);

        if (distanceToLeft > distanceToRight)
        {
            target = leftLimit;
        }
        else
        {
            target = rightLimit;
        }
        Flip();
    }

    private void Flip()
    {
        Vector3 rotation = transform.eulerAngles;
        if (transform.position.x < target.position.x)
        {
            rotation.y = 180f;
        }
        else
        {
            rotation.y = 0f;
        }
        transform.eulerAngles = rotation;
    }
}
