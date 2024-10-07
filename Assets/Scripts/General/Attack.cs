using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Attack : MonoBehaviour
{
    public float damage;
    public float attackRange;
    public float attackRate;
    private float explosionDamage;
    public float shootDamage;


    public Attack(float damage)
    {
        this.damage = damage;
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        other.GetComponent<Character>()?.TakeDamage(this);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<Character_Player>()?.TakeDamage(this);
    }
}
