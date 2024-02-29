using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crateHealth : MonoBehaviour
{
    

    private Rigidbody2D rigidbody2D;
    [SerializeField] float health, maxHealth = 3f;
    // [SerializeField] floatingHealthBar healthBar;

    public GameObject[] itemDrops;

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
            Destroy(gameObject);
            if (GetComponentInParent<EnemyPatrol>() != null)
            {
                GetComponentInParent<EnemyPatrol>().enabled = false;
            }
            ItemDrop();

        }
    }


    private void ItemDrop()
    {
        for (int i = 0; i < itemDrops.Length; i++)
        {
            Instantiate(itemDrops[i], transform.position + new Vector3(0, 1, 0), Quaternion.identity);
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

