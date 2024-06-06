using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunkerBusterDigger : MonoBehaviour
{
    [Header("Components for drilling")]
    [SerializeField] private GameObject bunkerBusterExplosion;
    public Rigidbody2D rb;
    public bool isTouchingGround = false;
    private float Speed = 5f;
    private bool timeToDig = false;
    private Vector3 targetPosition;

    [Header("Animators")]
    public Animator thisAnim;
    public Animator explosionAnim;
    public GameObject blinkingLightGO;


    [Header("After Explosion Components")]
    public SpriteRenderer sr;
    public Sprite destroyedDrill;
    public CircleCollider2D thisCircleCollider;


    private bool saveMeFromLoop = false; // Needed to add this as it's was the fastest option for disabling the drilling factor, but still doing ground checks

    void Update()
    {
        if (timeToDig)
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y - 20, 0), Speed * Time.deltaTime);
            
            if (this.gameObject.transform.position.y <= targetPosition.y)
            {
                rb.constraints = RigidbodyConstraints2D.None;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                if (isTouchingGround)
                {
                    rb.constraints = RigidbodyConstraints2D.FreezeAll;
                    StartCoroutine(BeepBeepBoom());
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!timeToDig && !saveMeFromLoop)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionY; // Stops drill from drilling at terminal velocity
            targetPosition = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y - 20, 0);
            timeToDig = true;
        }
        isTouchingGround = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        isTouchingGround = false;
    }


    // Most of the stuff in this coroutine is just animation and bool work to make the drill work with the explosion
    IEnumerator BeepBeepBoom()
    {
        saveMeFromLoop = true;
        timeToDig = false;
        thisAnim.SetBool("beep", true);
        blinkingLightGO.SetActive(true);
        yield return new WaitForSeconds(4); // Everything past this is destroying child objects on the drill, etc.
        Destroy(blinkingLightGO);
        thisAnim.enabled = false;
        bunkerBusterExplosion.SetActive(true); // Sets the GO to make the explosion go boom
        explosionAnim.SetBool("boom", true);
        sr.sprite = destroyedDrill;
        thisCircleCollider.enabled = false;
        this.enabled = false;
    }
}
