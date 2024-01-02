using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    public float BulletSpeed;
    public Rigidbody2D rb;
    //public float Damage;


    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * BulletSpeed;


    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent))
        {
            enemyComponent.TakeDamage(1);
            Destroy(gameObject);
        }

        else if (collision.tag == "Ladder")
        {

        }

        else
        {
            Destroy(gameObject);
        }

    }
}