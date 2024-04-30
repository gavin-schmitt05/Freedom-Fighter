using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor.Animations;
using UnityEngine;

public class MechControl : MonoBehaviour
{
    public float speed = 5f;
    private float direction = 0f;
    public float jumpSpeed = 8f;
    private Rigidbody2D mech;

    //Added to mech script
    [HideInInspector] private GameObject Player;
    [SerializeField] private BoxCollider2D Entrance;
    [HideInInspector] public bool playerIsDisabled = false;
    private bool inEntrance = false;
    public Transform mechTransform;


    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    public bool isTouchingGround;
    public Animator animator;
    public bool jump = false;
    //public playerHealth pHealth;
    private GameObject gun;


    // Start is called before the first frame update
    void Start()
    {
        mech = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player");
    }

    void Update()
    {
        if (inEntrance && Entrance != null)
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Player.SetActive(false);
                playerIsDisabled = true;
                CameraController.instance.changeCamera(mechTransform);
            }
            if (playerIsDisabled == true)
            {
                isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

                direction = Input.GetAxis("Horizontal");
                animator.SetFloat("speed", Mathf.Abs(direction));

                if (direction != 0f)
                {
                    mech.velocity = new Vector2(direction * speed, mech.velocity.y);
                    if (direction > 0)
                    {
                        gameObject.transform.localScale = new Vector3(-1, 1, 1);
                    }
                    else
                    {
                        gameObject.transform.localScale = new Vector3(1, 1, 1);
                    }
                }
                else
                {
                    mech.velocity = new Vector2(0, mech.velocity.y);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && playerIsDisabled == true)
        {
            Player.SetActive(true);
            playerIsDisabled = false;
            inEntrance = false;
            CameraController.instance.changeCamera(Player.transform);
        }
    }
        

    void OnTriggerEnter2D(Collider2D collision)
    {
        Collider2D col = collision.gameObject.GetComponent<Collider2D>();
        if (col.gameObject == Player)
        {
            inEntrance = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Collider2D col = collision.gameObject.GetComponent<Collider2D>();
        if (col.gameObject == Player)
        {
            inEntrance = false;
        }
    }
}
