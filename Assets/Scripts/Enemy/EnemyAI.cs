using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // 引用玩家对象
    public Transform player;

    // 追击速度和最大追击距离
    public float chaseSpeed = 5.0f;
    public float maxChaseDistance = 20.0f;

    // 敌人是否处于追击状态
    private bool isChasing = false;

    void Update()
    {   
        // 检查 player 是否为 null
    if (player == null)
    {
        Debug.LogWarning("Player object is missing or destroyed.");
        return;
    }

        // 计算玩家与敌人之间的距离
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // 如果距离小于最大追击距离，则开始追击
        if (distanceToPlayer < maxChaseDistance)
        {
            isChasing = true;
        }
        else
        {
            isChasing = false;
        }

        // 如果处于追击状态
        if (isChasing)
        {
            // 计算朝向玩家的方向
            Vector3 directionToPlayer = (player.position - transform.position).normalized;

            // 更新敌人的位置
            transform.position += directionToPlayer * chaseSpeed * Time.deltaTime;

            // 确保敌人始终面朝玩家
            if (directionToPlayer.x > 0 && transform.localScale.x < 0)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
            else if (directionToPlayer.x < 0 && transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }

    }
}