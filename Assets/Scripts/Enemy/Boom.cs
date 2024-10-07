using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Boom : MonoBehaviour
{   
    public float detectionRange = 5.0f; // 检测范围
    public float explosionDamage = 50.0f; // 爆炸伤害
    public float explosionDelay = 1.0f; // 爆炸延迟时间
    public Color alertColor = Color.red; // 区域变红的颜色
    public GameObject explosionEffect; // 爆炸效果预制件

    private Transform Player;
    private new Renderer renderer;
    private Color originalColor;
    private bool isExploding = false;
    public UnityEvent<Transform> OnTakeDamage;

    public class Attack
    {
        public Transform transform { get; set; }
        public float damage;
    }


    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player")?.transform;
        renderer = GetComponent<Renderer>();

        if (Player == null)
        {
            Debug.LogError("Player not found. Make sure the player has the 'Player' tag.");
        }

        if (renderer == null)
        {
            Debug.LogError("Renderer component not found.");
        }
        else
        {
            originalColor = renderer.material.color;
        }
    }

    private void Update()
    {
        if (Player == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, Player.position);

        if (distanceToPlayer <= detectionRange && !isExploding)
        {
            StartCoroutine(Explode());
        }
    }

    private IEnumerator Explode()
    {
        isExploding = true;

        // 改变区域颜色
        if (renderer != null)
        {
            renderer.material.color = alertColor;
        }

        // 等待爆炸延迟时间
        yield return new WaitForSeconds(explosionDelay);

        // 播放爆炸效果
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);
        }

        // 对玩家造成伤害
        if (Player != null)
        {
            Character playerCharacter = Player.GetComponent<Character>();
            if (playerCharacter != null)
            {
                Attack attack = new Attack { damage = explosionDamage };
                playerCharacter.TakeDamage(attack);
            }
            else
            {
                Debug.LogError("Character component not found on Player.");
            }
        }
        else
        {
            Debug.LogError("Player is null.");
        }

        if (Player != null)
        {
            Character_Player playerCharacter = Player.GetComponent<Character_Player>();
            if (playerCharacter != null)
            {
                Attack attack = new Attack { damage = explosionDamage };
                playerCharacter.TakeDamage(attack);
            }
            else
            {
                Debug.LogError("Character component not found on Player.");
            }
        }
        else
        {
            Debug.LogError("Player is null.");
        }


        // 恢复原始颜色
        if (renderer != null)
        {
            renderer.material.color = originalColor;
        }

        // 使敌人消失
        gameObject.SetActive(false);
    }
}
