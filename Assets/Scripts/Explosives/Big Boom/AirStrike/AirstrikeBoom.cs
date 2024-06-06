using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirstrikeBoom : MonoBehaviour
{
    public GameObject explosionDistanceGo;
    public LayerMask whatisPlatform;
    public CircleCollider2D circleCollider2D;

    public float SplashRange = 1;
    public float Damage;
    public Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        explosionDistanceGo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent))
        {
            enemyComponent.TakeDamage(10);
            explosionDistanceGo.SetActive(true);
            DestroyArea();
            Destroy(gameObject);
        }

        else if (collision.gameObject.TryGetComponent<crateHealth>(out crateHealth crateComponent))
        {
            crateComponent.TakeDamage(10);
            explosionDistanceGo.SetActive(true);
            DestroyArea();
            Destroy(gameObject);
        }

        else if (collision.CompareTag("Ladder"))
        {

        }

        else if (collision.CompareTag("Loot"))
        {

        }

        else if (collision.CompareTag("Background"))
        {

        }

        else
        {
            explosionDistanceGo.SetActive(true);
            DestroyArea();
            Destroy(gameObject);
        }
    }


    void DestroyArea()
    {
        int radiusInt = Mathf.RoundToInt(circleCollider2D.radius);
        for (int i = -radiusInt; i <= radiusInt; i++)
        {
            for (int j = -radiusInt; j <= radiusInt; j++)
            {
                Vector3 checkCellPos = new Vector3(transform.position.x + i, transform.position.y + j, 0);
                float distance = Vector2.Distance(transform.position, checkCellPos) - 0.001f;
                if (distance <= radiusInt)
                {
                    Collider2D[] overCollider2d = Physics2D.OverlapCircleAll(checkCellPos, 0.01f, whatisPlatform);
                    if (overCollider2d.Length > 0)
                    {
                        foreach (Collider2D overColl in overCollider2d)
                        {
                            overColl.GetComponent<Ground>().MakeDot(checkCellPos);
                        }
                    }
                }
            }
        }

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, SplashRange);

        foreach (Collider2D nearbyObject in colliders)
        {
            var obj = nearbyObject.GetComponent<Enemy>();
            var obs = nearbyObject.GetComponent<crateHealth>();
            var play = nearbyObject.GetComponent<playerHealth>();
            var dr = nearbyObject.GetComponent<doorHealth>();
            var extraction = nearbyObject.GetComponent<extractionHealth>();
            if (obj != null)
            {
                obj.TakeDamage(Damage);
            }
            if (obs != null)
            {
                obs.TakeDamage(Damage);
            }
            if (play != null)
            {
                play.gameObject.GetComponent<playerHealth>().health -= Damage;
            }
            if (dr != null)
            {
                dr.TakeDamage(Damage);
            }
            if (extraction != null)
            {
                extraction.TakeDamage(Damage);
            }
        }
    }
}
