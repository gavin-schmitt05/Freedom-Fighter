using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private GameObject Player;

    private GameObject Door;
    
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Door = GameObject.FindGameObjectWithTag("Door");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Door.GetComponent<Renderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
    }
    
}
