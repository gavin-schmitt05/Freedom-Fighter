using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField] private float range;
    public GameObject Bullet;
    public Rigidbody2D rb;
    public GameObject Enemy;

    public Transform FirePoint;
    public float FireRate;
    float ReadyForShot;
    public float direction = 0f;

    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Layers to hit")]
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private LayerMask obstacleLayer;

    [SerializeField] public float cooldownDuration;
    public float cooldownTimer;

    private bool playerCloseSight = false;

    //References
    private Animator anim;
    private EnemyPatrol enemyPatrol;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }

    private void Update()
    {
        //Attack only when player in sight
        if (PlayerInSight())
        {
            playerCloseSight = true; // True, so script knows player has been in range recently
            enemyPatrol.enabled = false; // Disabling so enemy doesn't walk and shoot
            anim.SetTrigger("rangedAttack");
            EnemyShoot();
        }

        // When player is out of sight, but just left it, defined by the playerCloseSight bool. Enemy will stare where player was last seen
        else if (!PlayerInSight() && playerCloseSight == true)
        {
            enemyPatrol.enabled = false;
            anim.SetBool("moving", false);
            cooldownTimer += Time.deltaTime; // Cooldown timer for how long enemy will stare at players last seen spot
            if (cooldownTimer > cooldownDuration)
            {
                cooldownTimer = 0;
                playerCloseSight = false; // Turns off playerCloseSight so enemy knows to keep patrolling as usual
            }
            if (enemyPatrol != null)
            {
                enemyPatrol.enabled = !PlayerInSight(); // Re-enable enemy patrol
            }
        }
    }

    private void EnemyShoot()
    {

        direction = Input.GetAxis("Horizontal");

        if (Enemy.transform.localScale == new Vector3(1, 1, 1))
        {
            FirePoint.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (Enemy.transform.localScale == new Vector3(-1, 1, 1))
        {
            FirePoint.transform.eulerAngles = new Vector3(0, 180, 0);
        }


        if (PlayerInSight())
        {
            if (Time.time > ReadyForShot)
            {
                ReadyForShot = Time.time + 1 / FireRate;
                shoot();
            }

        }
    }



    void shoot()
    {


        GameObject BulletIns = Instantiate(Bullet, FirePoint.position, FirePoint.rotation);

        Destroy(BulletIns, 3);
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(
            boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 0, Vector2.left, 0, playerLayer | obstacleLayer);

        if (hit.collider != null)
        {
            // Check if the detected collider is the player
            if (((1 << hit.collider.gameObject.layer) & playerLayer) != 0)
            {
                // Perform another raycast to check if there are any obstacles between the enemy and the player
                Vector2 direction = (hit.point - (Vector2)boxCollider.bounds.center).normalized;
                float distance = Vector2.Distance(hit.point, boxCollider.bounds.center);
                RaycastHit2D obstacleHit = Physics2D.Raycast(boxCollider.bounds.center, direction, distance, obstacleLayer);

                // If there's no obstacle, we can see the player
                return obstacleHit.collider == null;
            }
        }

        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Grenade"))
        {
            Panic();
        }
        else
        {

        }
    }

    private void Panic()
    {
        this.gameObject.SetActive(false);
    }

}

