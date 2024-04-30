using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crateHealth : MonoBehaviour
{
    

    private Rigidbody2D rigidbody2D;
    [SerializeField] float health, maxHealth = 3f;
    // [SerializeField] floatingHealthBar healthBar;

    public GameObject[] itemsToSpawn;
    [HideInInspector] public int itemSpawning;
    private System.Random rnd = new System.Random();

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        health = maxHealth;
    }

 

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        //  healthBar.UpdateHealthBar(health, maxHealth);
        if (health <= 0)
        {
            LootRandomizer();
            if (itemSpawning != 3)
            {
                ItemDrop();
            }
            Destroy(gameObject);
        }
    }

    private void LootRandomizer()
    {
        int percentagePicker = rnd.Next(1, 101);

        if (percentagePicker >= 1 && percentagePicker <= 50)
        {
            itemSpawning = 0;
        }
        else if (percentagePicker >= 51 && percentagePicker <= 75)
        {
            itemSpawning = 1;
        }
        else if (percentagePicker >= 76 && percentagePicker <= 88)
        {
            itemSpawning = 2;
        }
        else if (percentagePicker >= 89 && percentagePicker <= 100)
        {
            itemSpawning = 3;
        }
    }


    private void ItemDrop()
    {
        Instantiate(itemsToSpawn[itemSpawning], transform.position + new Vector3(0, 1, 0), Quaternion.identity);
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

