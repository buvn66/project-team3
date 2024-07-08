<<<<<<< HEAD
﻿using System.Collections;
=======
using System.Collections;
>>>>>>> f13587d0ec793d1aa51335840499e723e7039b74
using System.Collections.Generic;
using UnityEngine;

public class TimeLifeDestroyer : MonoBehaviour
{
<<<<<<< HEAD
    private Animator animator;
    public float AnimationDuration = 2f;
    private bool hasHit = false;
    public GameObject spawnObjectPrefab; // GameObject để spawn khi enemy bị destroy

    // Reference đến EnemyManager
    public Challenge challenge;

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
                SpawnSpawnObject(other.transform.position); // Gọi hàm để spawn game object mới

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

    // Phương thức để spawn GameObject mới
    void SpawnSpawnObject(Vector3 spawnPosition)
    {
        if (spawnObjectPrefab != null)
        {
            Instantiate(spawnObjectPrefab, spawnPosition, Quaternion.identity);
        }
    }

    // Coroutine để đợi cho đến khi animation kết thúc
    IEnumerator WaitForAnimationFinish()
    {
        yield return new WaitForSeconds(AnimationDuration);
        Destroy(gameObject); // Hủy viên đạn sau khi kết thúc animation

        // Gọi phương thức EnemyDestroyed của EnemyManager nếu đã được gán
        if (challenge != null)
        {
            challenge.EnemyDestroyed();
        }
=======
    public float LifeTime = 2f;

    private void Start()
    {
        Destroy(this.gameObject, LifeTime);
>>>>>>> f13587d0ec793d1aa51335840499e723e7039b74
    }
}
