using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform mainEnemyTransform;
    public float followDistance = 2f; // Khoảng cách theo sau vật chủ
    public float moveSpeed = 3f; // Tốc độ di chuyển

    public void SetMainEnemy(Transform mainEnemy)
    {
        mainEnemyTransform = mainEnemy;
    }

    void Update()
    {
        if (mainEnemyTransform != null)
        {
            Vector3 targetPosition = mainEnemyTransform.position - mainEnemyTransform.forward * followDistance;
            targetPosition.y = transform.position.y; // Giữ nguyên vị trí y để tránh di chuyển theo trục y

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }
}