using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeExplosion : MonoBehaviour
{
   
    public float impactField;
    
    public float Speed = 4;
    public Rigidbody2D rb;
  
    



    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * Speed;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, impactField);
    }
}