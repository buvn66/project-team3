using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLifeDestroyer : MonoBehaviour
{
    private Animator animator;
    public float AnimationDuration = 2f;
    private bool hasHit = false;
    void Start()
    {
        animator = GetComponent<Animator>();
        Destroy(gameObject, AnimationDuration + 0.1f);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasHit)
        {
            if (other.CompareTag("Enemy"))
            {
                hasHit = true;
                Destroy(other.gameObject);
                transform.position = other.transform.position;
                Rigidbody2D rb = GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.velocity = Vector2.zero;
                    rb.gravityScale = 0f;
                }

                if (animator != null)
                {
                    animator.SetTrigger("HitEnemy");
                    StartCoroutine(WaitForAnimationFinish());
                }
            }
        }
    }

    // Coroutine để đợi cho đến khi animation kết thúc
    IEnumerator WaitForAnimationFinish()
    {
        yield return new WaitForSeconds(AnimationDuration);
        Destroy(gameObject); // Hủy viên đạn sau khi kết thúc animation
    }
}
