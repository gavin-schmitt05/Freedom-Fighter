using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeExplosion : MonoBehaviour
{

    public float impactField;
    public float force;
    public LayerMask LayerToHit;
    float GrenadeTimer = 3f;
    public float Speed = 4;
    public Rigidbody2D rb;
    public LayerMask whatisPlatform;



    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * Speed;
    }

    // Update is called once per frame
    void Update()
    {
        GrenadeTimer -= Time.deltaTime;
        if (GrenadeTimer <= 0)
        {
            explode();
            
        }
    }
    

    void explode()
    {
       Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, impactField, LayerToHit);


        foreach(Collider2D obj in objects)
        {
            Vector2 direction = obj.transform.position - transform.position;

            obj.GetComponent<Rigidbody2D>().AddForce(direction * force);
        }

        Destroy(gameObject, 1);
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, impactField);
    }





}
