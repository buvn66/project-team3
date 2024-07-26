//using UnityEngine;
//using UnityEngine.UI;

//public class BossNew : MonoBehaviour
//{
//    public float moveSpeed = 2f;
//    public float attackRange = 5f;
//    public float attackCooldown = 1f;
//    public GameObject player;
//    public int maxHealth = 100;
//    public int attackDamage = 10; // Thêm biến sát thương



//    private Animator animator;
//    private float lastAttackTime;
//    private int currentHealth;

    

//    void Start()
//    {
//        animator = GetComponent<Animator>();
//        lastAttackTime = 0f;
//        currentHealth = maxHealth;
//    }

//    void Update()
//    {
//        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

//        // Kiểm tra nếu boss đã chết
//        if (currentHealth <= 0)
//        {
//            animator.SetBool("isDead", true);
//            return; // Dừng mọi hành động nếu boss đã chết
//        }

//        // Kiểm tra khoảng cách với nhân vật
//        if (distanceToPlayer < attackRange)
//        {
//            MoveTowardsPlayer();
//            animator.SetBool("isWalking", true);

//            // Chỉ tấn công nếu đủ thời gian hồi chiêu
//            if (Time.time >= lastAttackTime + attackCooldown)
//            {
//                AttackPlayer();
//            }
//        }
//        else
//        {
//            animator.SetBool("isWalking", false);
//        }
//    }

//    void MoveTowardsPlayer()
//    {
//        Vector2 direction = (player.transform.position - transform.position).normalized;
//        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);

//        // Quay boss về phía nhân vật
//        if (direction != Vector2.zero) // Kiểm tra để tránh lỗi chia cho 0
//        {
//            // Kiểm tra hướng để quay trái hoặc phải
//            if (direction.x > 0)
//            {
//                transform.localScale = new Vector3(-1, 1, 1); // Quay sang phải
//            }
//            else
//            {
//                transform.localScale = new Vector3(1, 1, 1); // Quay sang trái
//            }
//        }
//    }


//    void AttackPlayer()
//    {
//        lastAttackTime = Time.time;
//        animator.SetBool("isAttacking", true);

//        // Gây sát thương cho nhân vật
//        Player playerComponent = player.GetComponent<Player>(); // Lấy component Player
//        if (playerComponent != null)
//        {
//            playerComponent.TakeDamage(attackDamage); // Gọi phương thức TakeDamage trên nhân vật
//        }

//        // Sau khi tấn công xong, quay lại trạng thái không tấn công
//        Invoke("ResetAttack", 1f); // Thay đổi thời gian nếu cần
//    }

//    void ResetAttack()
//    {
//        animator.SetBool("isAttacking", false);
//    }

//    public void TakeDamage(int damage)
//    {
//        currentHealth -= damage; // Giảm máu
//        animator.SetTrigger("BossHurt"); // Kích hoạt animation bị thương

//        // Kiểm tra nếu boss chết
//        if (currentHealth <= 0)
//        {
//            animator.SetBool("isDead", true);
//        }
//    }

//    private void OnDrawGizmosSelected()
//    {
//        Gizmos.color = Color.red;
//        Gizmos.DrawWireSphere(transform.position, attackRange);
//    }
//}
