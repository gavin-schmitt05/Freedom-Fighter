using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    public float BulletSpeed;
    public Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * BulletSpeed;


    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent))
        {
            enemyComponent.TakeDamage(1);
            Destroy(gameObject);
        }

        else if (other.gameObject.CompareTag("Ladder"))
        {

        }

        else if (other.gameObject.TryGetComponent<crateHealth>(out crateHealth crateComponent))
        {
            crateComponent.TakeDamage(1);
            Destroy(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }

    }

}