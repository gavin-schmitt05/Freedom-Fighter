using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetDamage : MonoBehaviour
{
    void Start()
    {
        Physics2D.IgnoreLayerCollision(6, 6);
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent))
        {
            enemyComponent.TakeDamage(3);
            Destroy(collision.transform.parent.gameObject);
        }
        else if (collision.gameObject.TryGetComponent<crateHealth>(out crateHealth crateComponent))
        {
            crateComponent.TakeDamage(3);
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Extract"))
        {
            Destroy(collision.gameObject);
        }
    }
}
