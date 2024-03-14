using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

        }
        else if (collision.gameObject.CompareTag("Bullet"))
        {

        }
        else if (collision.gameObject.CompareTag("Ground"))
        {

        }
        else if (collision.gameObject.CompareTag("Gun"))
        {

        }
    }
       

    
    

  

}
