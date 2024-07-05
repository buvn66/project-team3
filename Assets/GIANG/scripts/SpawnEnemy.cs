using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject EnemyPrefab; // Đổi tên biến từ EnemyPrefabs thành EnemyPrefab vì chỉ spawn 1 loại enemy
    public int numberOfEnemiesToSpawn = 10; // Số lượng enemy cần spawn
    public float spawnRate = 1.5f;
    public float spawnRadius = 5f;

    private float spawnTimer = 0f;
    private int enemiesSpawned = 0;
    private bool isSpawning = true;

    void Update()
    {
        if (isSpawning)
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer >= spawnRate && enemiesSpawned < numberOfEnemiesToSpawn)
            {
                spawnEnemy();
                spawnTimer = 0f;
                enemiesSpawned++;
            }

            // Kiểm tra xem đã spawn đủ số lượng enemy chưa
            if (enemiesSpawned >= numberOfEnemiesToSpawn)
            {
                isSpawning = false; // Tắt chế độ spawn khi đã đủ số lượng
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
    void spawnEnemy()
    {
        Vector2 randomPosition = (Vector2)transform.position + Random.insideUnitCircle.normalized * spawnRadius;

        Instantiate(EnemyPrefab, randomPosition, Quaternion.identity);
    }
}
