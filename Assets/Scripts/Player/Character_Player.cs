using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character_Player : MonoBehaviour
{
    public GameObject Player;

    [Header("基本属性")]
    public float maxHealth;
    public float currentHealth;

    [Header("受伤无敌")]
    public float invulnerableTime;
    public float invulnerableCounter;
    public bool invulnerable;
    public UnityEvent<Character_Player> OnHealthChange;
    public UnityEvent<Transform> OnTakeDamage;

     [Header("音频")]
    public AudioClip takeDamageClip; // 受伤音频
    private AudioSource audioSource; // 音频源

    private void Start()
    {
        currentHealth = maxHealth;
        audioSource = GetComponent<AudioSource>();
        Player = this.gameObject;
    }


    private void Update()
    {
        if(invulnerable)
        {
            invulnerableCounter -= Time.deltaTime;
            if(invulnerableCounter <= 0)
            {
                invulnerable = false;
            }
        }

    }

 
    public void TakeDamage(Attack attacker)
    {
        if(invulnerable)
        {
            return;
        }
        // Debug.Log(attacker.damage);
        if(currentHealth -attacker.damage <= 0)
        {
            currentHealth = 0;
            Player = null;
            if (Player == null)
        {
            Debug.Log("Player is null, loading GameOver scene.");
            // 加载GameOver场景
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        }
            gameObject.SetActive(false);
            OnHealthChange?.Invoke(this);
            return;
        }
        currentHealth -= attacker.damage;

        if (audioSource != null && takeDamageClip != null)
        {
            audioSource.PlayOneShot(takeDamageClip);
        }

        TriggerInvulnerable();
        //执行受伤
        OnTakeDamage?.Invoke(attacker.transform);

        OnHealthChange?.Invoke(this);
    }
        public void TakeDamage(Boom.Attack attacker)
    {
                if(invulnerable)
            {
                    return;
            }
            // Debug.Log(attacker.damage);
            if(currentHealth -attacker.damage <= 0)
            {
                currentHealth = 0;
                Player = null;
                gameObject.SetActive(false);
                 if (Player == null)
        {
            Debug.Log("Player is null, loading GameOver scene.");
            // 加载GameOver场景
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        }
                OnHealthChange?.Invoke(this);
                return;
            }
                currentHealth -= attacker.damage;

                if (audioSource != null && takeDamageClip != null)
            {
                audioSource.PlayOneShot(takeDamageClip);
            }

                TriggerInvulnerable();
                //执行受伤
                OnTakeDamage?.Invoke(attacker.transform);

                OnHealthChange?.Invoke(this);
    }

    public void TakeDamage(EnemyShooting.Attack attacker)
    {
        if(invulnerable)
            {
                    return;
            }
            // Debug.Log(attacker.damage);
            if(currentHealth -attacker.damage <= 0)
            {
                currentHealth = 0;
                Player = null;
                gameObject.SetActive(false);
                 if (Player == null)
        {
            Debug.Log("Player is null, loading GameOver scene.");
            // 加载GameOver场景
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        }
                OnHealthChange?.Invoke(this);
                return;
            }

            if (audioSource != null && takeDamageClip != null)
            {
                audioSource.PlayOneShot(takeDamageClip);
            }
            
                currentHealth -= attacker.damage;

                TriggerInvulnerable();
                //执行受伤
                OnTakeDamage?.Invoke(attacker.transform);

                OnHealthChange?.Invoke(this);
    }
   
    /// <summary>
    /// 触发受伤无敌
    /// </summary>
    private void TriggerInvulnerable()
    {
        if(!invulnerable)
        {
            invulnerable = true;
            invulnerableCounter = invulnerableTime;
        }
    }

    internal void TakeDamage(float explosionDamage)
    {
        throw new NotImplementedException();
    }
}

