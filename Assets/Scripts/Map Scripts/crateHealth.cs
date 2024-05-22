using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crateHealth : MonoBehaviour
{
    

    private Rigidbody2D rigidbody2D;
    [SerializeField] float health, maxHealth = 3f;
    // [SerializeField] floatingHealthBar healthBar;

    public GameObject[] commonItem;
    public GameObject[] uncommonItem;
    public GameObject[] rareItem;
    [HideInInspector] public int itemSpawning;
    private System.Random rndRarety = new System.Random();
    private System.Random rndItem = new System.Random();

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        health = maxHealth;
    }

 

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount; 
        if (health <= 0)
        {
            LootRandomizer();
            Destroy(gameObject);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;

        }
        else if(collision.gameObject.CompareTag("Ground"))
        {
            rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        }
        else if (collision.gameObject.CompareTag("Grenade"))
        {
            rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        }
        else
        {
            rigidbody2D.constraints = 0;
        }
       
    }

}

