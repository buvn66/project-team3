using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPAM : MonoBehaviour
{
    public GameObject enemyPrefab; // Đối tượng kẻ thù
    [SerializeField]
    public float spawnRate = 1.5f; // Tốc độ sinh ra kẻ thù
    [SerializeField]
    private float spawnTimer = 1f; // Bộ đếm thời gian cho việc sinh ra kẻ thù
    [SerializeField]
    private int maxEnemies = 10; // Số lượng kẻ thù tối đa có thể sinh ra
    [SerializeField]
    public float spawnRadius = 5f; // Bán kính sinh ra kẻ thù
    private int enemiesSpawned = 0; // Đếm số lượng kẻ thù đã sinh ra
    [SerializeField]
    private float lineLength = 10f; // Chiều dài của đường thẳng sinh ra kẻ thù
    private Transform mainEnemyTransform;

    void Start()
    {
        mainEnemyTransform = transform; // Giả sử quái vật chính là đối tượng mà mã này đính kèm
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer > spawnRate && enemiesSpawned < maxEnemies)
        {
            SpawnEnemy();
            spawnTimer = 0f; // Đặt lại bộ đếm thời gian
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position - Vector3.right * lineLength / 2, transform.position + Vector3.right * lineLength / 2); // Vẽ đường thẳng sinh ra kẻ thù
    }

    void SpawnEnemy()
    {
        // Tạo vị trí ngẫu nhiên dọc theo đường thẳng
        Vector2 randomPosition = (Vector2)transform.position + new Vector2(
            Random.Range(-lineLength / 2, lineLength / 2),
            0 // Đặt y = 0 để đảm bảo kẻ thù sinh ra trên một đường thẳng nằm ngang
        );

        GameObject newEnemy = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);

        // Thiết lập để quái vật mới di chuyển theo quái vật chính
        EnemyMovement enemyMovement = newEnemy.GetComponent<EnemyMovement>();
        if (enemyMovement != null)
        {
            enemyMovement.SetMainEnemy(mainEnemyTransform);
        }

        // Tăng số lượng kẻ thù đã sinh ra
        enemiesSpawned++;
    }
}