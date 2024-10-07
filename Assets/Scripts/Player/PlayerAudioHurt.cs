using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioHurt : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip hurtClip;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // 如果 AudioSource 组件不存在，则动态添加
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // 确保 AudioClip 已分配
        if (hurtClip == null)
        {
            Debug.LogError("Hurt audio clip is not assigned.");
        }
        else
        {
            Debug.Log("Hurt audio clip assigned successfully.");
        }
    }

    public void TakeDamage(Attack attacker)
    {
        // 播放扣血音效
        if (audioSource != null && hurtClip != null)
        {
            audioSource.clip = hurtClip;
            audioSource.Play();
        }
    }
}