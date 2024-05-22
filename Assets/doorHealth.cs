using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorHealth : MonoBehaviour
{
   [SerializeField] float health, maxHealth = 3f;
    // Start is called before the first frame update
    private void Start()
    {
        
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        //  healthBar.UpdateHealthBar(health, maxHealth);
        if (health <= 0)
        {
            
            Destroy(gameObject);
        }
    }
}
