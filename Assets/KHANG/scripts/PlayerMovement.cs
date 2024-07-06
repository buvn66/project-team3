using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        // Lấy input từ bàn phím
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Tạo vector di chuyển
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Di chuyển player
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
    }
}
