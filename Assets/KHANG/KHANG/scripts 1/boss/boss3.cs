using UnityEngine;

public class Boss3 : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 10f;
    private bool movingRight = true;
    private bool chasingPlayer = false;
    private Transform player;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (chasingPlayer && player != null)
        {
            ChasePlayer();
        }
        else
        {
            Move();
        }
    }

    void Move()
    {
        if (movingRight)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }
    }

    void ChasePlayer()
    {
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, player.position, step);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            chasingPlayer = false;
            player = null;
        }
    }

    void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
