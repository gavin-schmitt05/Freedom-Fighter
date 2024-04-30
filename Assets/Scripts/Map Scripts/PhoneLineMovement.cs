using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneLineMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private bool isPhoneLine;
    private bool isClimbing;

    [SerializeField] private Rigidbody2D rb;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (isPhoneLine && Mathf.Abs(horizontal) > 0f)
        {
            isClimbing = true;
        }
    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, horizontal * speed);
        }
        else
        {
            rb.gravityScale = 2f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PhoneLine"))
        {
            isPhoneLine = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PhoneLine"))
        {
            isPhoneLine = false;
            isClimbing = false;
        }
    }
}
