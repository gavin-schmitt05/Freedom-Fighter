using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float BulletSpeed;
    public Rigidbody2D rb;

   


    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * BulletSpeed;
        Destroy(this.gameObject, 3);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent))
        {
            enemyComponent.TakeDamage(1);
            Destroy(gameObject);
        }

        else if (collision.gameObject.TryGetComponent<crateHealth>(out crateHealth crateComponent))
        {
            crateComponent.TakeDamage(1);
            Destroy(gameObject);
        }
        else if (collision.gameObject.TryGetComponent<doorHealth>(out doorHealth doorComponent))
        {
            doorComponent.TakeDamage(1);
            Destroy(gameObject);
        }
        else if (collision.tag == "ExtractionZone")
        {

        }

        else if(collision.tag == "Ladder")
        {
            
        }
        else if (collision.tag == "Bullet")
        {
            
        }

        else
        {
            Destroy(gameObject);
        }
            
    }
}

