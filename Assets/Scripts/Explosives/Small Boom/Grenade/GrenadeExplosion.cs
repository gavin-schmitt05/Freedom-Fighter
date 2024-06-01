using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeExplosion : MonoBehaviour
{
   
    public float impactField;
    
    public float Speed = 8;
    public Rigidbody2D rb;
  
    



    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(transform.up * 85);
        rb.velocity = transform.right * Speed;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, impactField);
    }
}