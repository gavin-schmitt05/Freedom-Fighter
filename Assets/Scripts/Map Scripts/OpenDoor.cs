using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Sprite openedDoor;
    public BoxCollider2D doorCollider;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.GetComponent<SpriteRenderer>().sprite = openedDoor;
            doorCollider.enabled = false;
        }
    }
}

       

    
    

  

