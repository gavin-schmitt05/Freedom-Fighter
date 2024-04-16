using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IDataPersistence
{


    public float speed = 5f;
    private float direction = 0f;
    public float jumpSpeed = 8f;
    private Rigidbody2D player;
    

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    public bool isTouchingGround;
    public Animator animator;
    bool jump = false;
    public playerHealth pHealth;
    private GameObject gun;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        gun = GameObject.FindGameObjectWithTag("Gun");
    }

    public void LoadData(GameData data)
    {
        this.transform.position = data.playerPosition;
    }

    public void SaveData(GameData data)
    {
        data.playerPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        direction = Input.GetAxis("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(direction));

        if (pHealth.health > 0)
        {
            animator.SetBool("death", false);

            if (direction > 0f)
            {
                player.velocity = new Vector2(direction * speed, player.velocity.y);
            }

            else if (direction < 0)
            {
                player.velocity = new Vector2(direction * speed, player.velocity.y);
            }

            else
            {
                player.velocity = new Vector2(0, player.velocity.y);
            }

            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
                animator.SetBool("IsJumping", true);
            }

            if (Input.GetButtonDown("Jump") && isTouchingGround)
            {
                player.velocity = new Vector2(player.velocity.x, jumpSpeed);

            }

            if (direction > 0)
            {
                gameObject.transform.localScale = new Vector3(1, 1, 1);
            }
            else if (direction < 0)
            {
                player.transform.localScale = new Vector3(-1, 1, 1);
            }


            if (isTouchingGround)
            {
                animator.SetBool("IsJumping", false);
            }

            else if (isTouchingGround == false)
            {
                animator.SetBool("IsJumping", true);
            }
        }


        else if (pHealth.health <= 0) {

            animator.SetBool("death", true);
            PlayerDied();
        }
    }

    private void PlayerDied()
    {
        LevelManager.instance.GameOver();
        gameObject.SetActive(false);
        GetComponent<PlayerMovement>().enabled = false;
        //DataPersistenceManager.instance.NewGame();
    }

}
