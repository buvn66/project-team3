using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BossEnemy : MonoBehaviour
{
    private Transform player;
    public int attackDamage = 5; // Giá trị sát thương của Boss là 5
    public float attackRange = 3f;
    private Player playerScript;
    private float attackCooldown = 2f; // Thời gian chờ giữa các lần tấn công
    private float lastAttackTime;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player != null)
        {
            playerScript = player.GetComponent<Player>();
        }
        lastAttackTime = -attackCooldown; // Để Boss có thể tấn công ngay từ đầu
    }

    public void LookAtPlayer()
    {
        if (player == null)
            return;

        Vector3 scale = transform.localScale;
        if (transform.position.x > player.position.x && scale.x > 0)
        {
            scale.x *= -1;
        }
        else if (transform.position.x < player.position.x && scale.x < 0)
        {
            scale.x *= -1;
        }
        transform.localScale = scale;
    }

    public void AttackPlayer()
    {
        if (player == null || playerScript == null)
            return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange && Time.time >= lastAttackTime + attackCooldown)
        {
            //playerScript.TakeDamage(attackDamage);
            Debug.Log("Boss attacked the player!");
            lastAttackTime = Time.time; // Cập nhật thời gian tấn công cuối cùng
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}