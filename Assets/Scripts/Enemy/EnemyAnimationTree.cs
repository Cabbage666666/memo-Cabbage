using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationTree : MonoBehaviour
{
    public float detectionRange = 5.0f; // 检测范围
    private Transform player; // 玩家 Transform
    private Animator animator; // 动画控制器
    private bool isPlayerNearby = false; // 跟踪玩家是否在检测范围内

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        animator = GetComponent<Animator>();

        if (player == null)
        {
            Debug.LogError("Player not found. Make sure the player has the 'Player' tag.");
        }

        if (animator == null)
        {
            Debug.LogError("Animator component not found.");
        }
    }

    private void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange && !isPlayerNearby)
        {
            PlayAnimation();
        }
        else if (distanceToPlayer > detectionRange && isPlayerNearby)
        {
            StopAnimation();
        }
    }

    private void PlayAnimation()
    {
        if (animator != null)
        {
            animator.SetBool("isPlayerNearby", true);
            isPlayerNearby = true; // 标记玩家在检测范围内
        }
    }

    private void StopAnimation()
    {
        if (animator != null)
        {
            animator.SetBool("isPlayerNearby", false);
            isPlayerNearby = false; // 标记玩家不在检测范围内
        }
    }
}
