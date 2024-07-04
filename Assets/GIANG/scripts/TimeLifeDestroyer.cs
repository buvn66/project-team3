using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLifeDestroyer : MonoBehaviour
{
    private Animator animator;
    public float LifeTime = 2f;
    private bool hasHit = false;
    void Start()
    {
        animator = GetComponent<Animator>();
        Destroy(gameObject, LifeTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!hasHit)
        {
            if (other.CompareTag("Enemy"))
            {
                animator.SetTrigger("HitEnemy");
                hasHit = true;
                Destroy(other.gameObject);
            }
        }
    }
}
