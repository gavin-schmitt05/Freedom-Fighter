using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class DoorCollisions : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // thecollider component
        Collider2D collider = GetComponent<Collider2D>();

        // 
        collider.enabled = false;
    }
}