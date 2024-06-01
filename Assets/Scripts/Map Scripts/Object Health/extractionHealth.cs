using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class extractionHealth : MonoBehaviour
{
    [SerializeField] float health, maxHealth = 3f;
    // Start is called before the first frame update
    void Start()
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
            Destroy(this.gameObject);
        }
    }
}
