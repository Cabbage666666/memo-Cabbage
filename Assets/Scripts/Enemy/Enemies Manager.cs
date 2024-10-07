using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    public GameObject enemyPrefab; // 敌人预制体
    public Transform player;       // 玩家对象
    public float spawnRadiusMin = 10f;  // 环形区域的内半径
    public float spawnRadiusMax = 12f; // 环形区域的外半径
    public int enemiesPerSpawn = 2;    // 每次生成的敌人数量
    public float spawnInterval = 5f;   // 生成间隔时间

    private float timer;

    void Start()
    {
        timer = spawnInterval;

        // 检查玩家对象是否存在
        if (player == null)
        {
            Debug.LogError("Player object is missing or destroyed.");
        }
    }

    void Update()
    {
        // 检查玩家对象是否存在
        if (player == null)
        {
            Debug.LogWarning("Player object is missing or destroyed.");
            return;
        }
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            SpawnEnemies();
            timer = spawnInterval;
        }
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < enemiesPerSpawn; i++)
        {
            Vector2 spawnPosition = GetRandomPosition();
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }

    Vector2 GetRandomPosition()
    {
        float distance = Random.Range(spawnRadiusMin, spawnRadiusMax);
        float angle = Random.Range(0f, 360f);
        float spawnPosX = player.position.x + distance * Mathf.Cos(angle * Mathf.Deg2Rad);
        float spawnPosY = player.position.y + distance * Mathf.Sin(angle * Mathf.Deg2Rad);

        return new Vector2(spawnPosX, spawnPosY);
    }
}