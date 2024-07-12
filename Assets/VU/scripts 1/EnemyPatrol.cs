using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float moveSpeed = 2f; // Tốc độ di chuyển của quái
    public float start, end; // điểm bắt đầu , điểm kết thúc 
    private Vector3 targetPosition; // Vị trí mục tiêu để di chuyển đến

    void Start()
    {
        // Ban đầu quái vật sẽ di chuyển tới điểm bắt đầu
        targetPosition = new Vector3(start, transform.position.y, transform.position.z);
    }

    void Update()
    {
        // Di chuyển con quái vật đến vị trí mục tiêu
        MoveToTarget();
    }

    // Hàm di chuyển con quái vật đến vị trí mục tiêu
    void MoveToTarget()
    {
        // Tính toán hướng di chuyển của quái vật
        Vector3 moveDirection = (targetPosition - transform.position).normalized;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // Xoay mặt quái vật theo hướng di chuyển
        if (moveDirection.x > 0)
        {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }
        else if (moveDirection.x < 0)
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        }

        // Kiểm tra nếu quái vật đã gần đến vị trí mục tiêu, thay đổi mục tiêu mới
        if (Mathf.Abs(transform.position.x - targetPosition.x) < 0.1f)
        {
            // Đổi hướng di chuyển tới điểm kết thúc nếu đã đến điểm bắt đầu
            if (targetPosition.x == start)
            {
                targetPosition.x = end;
            }
            // Đổi hướng di chuyển tới điểm bắt đầu nếu đã đến điểm kết thúc
            else if (targetPosition.x == end)
            {
                targetPosition.x = start;
            }
        }
    }
}
