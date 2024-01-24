using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health, maxHealth = 3f;
    [SerializeField] floatingHealthBar healthBar;

    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        healthBar.UpdateHealthBar(health, maxHealth);
        if(health <= 0)
        {
            Destroy(gameObject);
            if(GetComponentInParent<EnemyPatrol>() != null)
            {
                GetComponentInParent<EnemyPatrol>().enabled = false;
            }
                
        }
    }
}
