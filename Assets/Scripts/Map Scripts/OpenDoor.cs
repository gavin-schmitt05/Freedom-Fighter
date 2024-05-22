
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Sprite opened;
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
            gameObject.GetComponent<SpriteRenderer>().sprite = opened;
            doorCollider.enabled = false;
        }
        if (collision.gameObject.tag == "Strong Enemy")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = opened;
            doorCollider.enabled = false;
        }
    }
}
