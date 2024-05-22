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

    public GameObject[] commonItem;
    public GameObject[] uncommonItem;
    public GameObject[] rareItem;
    [HideInInspector] public int itemSpawning;
    private System.Random rndRarety = new System.Random();
    private System.Random rndItem = new System.Random();

    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            LootRandomizer();
            Destroy(gameObject);
            if (GetComponentInParent<EnemyPatrol>() != null)
            {
                GetComponentInParent<EnemyPatrol>().enabled = false;
            }
        }
    }

    private void LootRandomizer()
    {
        int raretyOfItem = rndRarety.Next(1, 5);
        int itemSpawning = 0;

        if (raretyOfItem == 1)
        {
            itemSpawning = rndItem.Next(1,4);
            Instantiate(commonItem[itemSpawning], transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
        else if (raretyOfItem == 2)
        {
            itemSpawning = 1;
            Instantiate(uncommonItem[itemSpawning], transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
        else if (raretyOfItem == 3)
        {
            Instantiate(rareItem[itemSpawning], transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }
}
