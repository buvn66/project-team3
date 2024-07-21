using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    public float speed = 2.0f; // Tốc độ di chuyển của thang máy
    public float height = 5.0f; // Khoảng cách giữa điểm lên và điểm xuống

    private Vector3 startPosition;
    private Vector3 endPosition;
    private float timeElapsed = 0.0f;

    void Start()
    {
        // Lưu vị trí ban đầu và tính toán vị trí điểm kết thúc
        startPosition = transform.position;
        endPosition = startPosition + Vector3.up * height;
    }

    void Update()
    {
        // Tính toán thời gian đã trôi qua
        timeElapsed += Time.deltaTime * speed;

        // Sử dụng Mathf.PingPong để di chuyển giữa hai điểm
        float pingPongValue = Mathf.PingPong(timeElapsed, 1);
        transform.position = Vector3.Lerp(startPosition, endPosition, pingPongValue);
    }
}
