using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health, maxHealth = 3f;
   // [SerializeField] floatingHealthBar healthBar;

    public GameObject[] itemDrops;

    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
      //  healthBar.UpdateHealthBar(health, maxHealth);
        if(health <= 0)
        {
            Destroy(gameObject);
            if(GetComponentInParent<EnemyPatrol>() != null)
            {
                GetComponentInParent<EnemyPatrol>().enabled = false;
            }
            ItemDrop();
                
        }
    }


    private void ItemDrop()
    {
        for(int i = 0; i < itemDrops.Length; i++)
        {
            Instantiate(itemDrops[i], transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }

}
