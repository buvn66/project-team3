
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Spam : MonoBehaviour
{
    public GameObject enemyPrefabs;
    [SerializeField]
    public float spawnRarte = 1.5f;
    [SerializeField]
    public float spawnRadius = 5f;
    [SerializeField]
    private float spawnTimer = 1f;
    void Start()
    {

    }
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer > spawnRadius)
        {
            SpawnEnemy();
            spawnTimer = 1f;
        }

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
    void SpawnEnemy()
    {
        Vector2 randomPosition = (Vector2)transform.position + Random.insideUnitCircle.normalized * spawnRadius;

        Instantiate(enemyPrefabs, randomPosition, Quaternion.identity);
    }
}