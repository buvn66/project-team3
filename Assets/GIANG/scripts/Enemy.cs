using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject EnemyPrefabs;
    public float spawnRate = 1.5f;
    public float spawnRadius = 5f;
    private float spawnTimes = 0f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        spawnTimes += Time.deltaTime;
        if (spawnTimes >= spawnRate)
        {
            spawnEnemy();
            spawnTimes = 0f;
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

        Instantiate(EnemyPrefabs, randomPosition, Quaternion.identity);
    }
}
