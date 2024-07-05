using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab của enemy cần spawn
    public int spawnCount = 10; // Số lượng enemy cần spawn
    public float spawnRate = 1.5f; // Thời gian giữa các lần spawn
    public float spawnRadius = 5f; // Bán kính xung quanh spawner để spawn enemy

    private int enemiesSpawned = 0; // Số lượng enemy đã spawn
    private float spawnTimer = 0f; // Đếm thời gian giữa các lần spawn
    private bool isSpawning = true; // Biến để kiểm tra xem có đang spawn enemy hay không

    void Update()
    {
        if (isSpawning)
        {
            spawnTimer += Time.deltaTime; // Tăng spawnTimer theo thời gian thực
            if (spawnTimer >= spawnRate && enemiesSpawned < spawnCount)
            {
                spawnEnemy(); // Gọi hàm spawnEnemy để spawn enemy
                spawnTimer = 0f; // Reset spawnTimer sau khi spawn
                enemiesSpawned++; // Tăng số lượng enemy đã spawn
            }

            // Kiểm tra nếu đã spawn đủ số lượng enemy thì tắt isSpawning
            if (enemiesSpawned >= spawnCount)
            {
                isSpawning = false;
            }
        }
    }

    void spawnEnemy()
    {
        // Tính toán vị trí ngẫu nhiên xung quanh spawner
        Vector2 randomPosition = (Vector2)transform.position + Random.insideUnitCircle.normalized * spawnRadius;

        // Spawn enemy tại vị trí ngẫu nhiên tính được
        Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
    }

    // Vẽ hình cầu màu vàng xung quanh spawner trong Scene Editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}
