using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health, maxHealth = 3f;

    //For enemy health bars possibly
    //[SerializeField] floatingHealthBar healthBar;

    //public GameObject[] itemDrops;
    public GameObject[] itemsToSpawn;
    [HideInInspector] public int itemSpawning;
    private System.Random rnd = new System.Random();

    private void Start()
    {
        health = maxHealth;
        LootRandomizer();
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        //For enemy health bars possibly
        //healthBar.UpdateHealthBar(health, maxHealth);
        if (health <= 0)
        {
            Destroy(gameObject);
            if (GetComponentInParent<EnemyPatrol>() != null)
            {
                GetComponentInParent<EnemyPatrol>().enabled = false;
            }
            if (itemSpawning != 3)
            {
                ItemDrop();
            }


        }
    }

    private void LootRandomizer()
    {
        int percentagePicker = rnd.Next(1, 101);

        if (percentagePicker >= 1 && percentagePicker <= 50)
        {
            Debug.Log("Spawning assualt rifle");
            itemSpawning = 0;
        }
        else if (percentagePicker >= 51 && percentagePicker <= 75)
        {
            Debug.Log("Spawning coin");
            itemSpawning = 1;
        }
        else if (percentagePicker >= 76 && percentagePicker <= 88)
        {
            Debug.Log("Spawning grenade");
            itemSpawning = 2;
        }
        else if (percentagePicker >= 89 && percentagePicker <= 100)
        {
            Debug.Log("You got nothing lol");
            itemSpawning = 3;
        }
        
    }

    private void ItemDrop()
    {
        Instantiate(itemsToSpawn[itemSpawning], transform.position + new Vector3(0, 1, 0), Quaternion.identity);
    }

}
