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
    [HideInInspector] private bool playerEnteredMech = false;
    private bool playerInEntrance = false;
    [SerializeField] private Transform mechTransform;

    
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    public bool isTouchingGround;
    public Animator animator;
    public bool jump = false;
    //public playerHealth pHealth;
    //private GameObject gun;


    // Start is called before the first frame update
    void Start()
    {
        mech = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player");

    }

    void Update()
    {
        if (playerInEntrance)
        {
            if (Input.GetKeyDown(KeyCode.Alpha2) && playerEnteredMech == true)
            {
                Player.transform.position = Entrance.bounds.center;
                Player.SetActive(true);
                playerEnteredMech = false;
                CameraController.instance.changeCamera(Player.transform);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Player.SetActive(false);
                playerEnteredMech = true;
                CameraController.instance.changeCamera(mechTransform);
            }
            if (playerEnteredMech == true)
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
    }
        

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Player)
        {
            playerInEntrance = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == Player && Player.activeInHierarchy == true)
        {
            playerInEntrance = false;
        }
    }
}
