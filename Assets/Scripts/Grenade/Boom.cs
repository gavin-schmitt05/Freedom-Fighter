using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{

    public GameObject explosionDistanceGo;
    public LayerMask whatisPlatform;
    public CircleCollider2D circleCollider2D;
    public float SplashRange = 1;
    public playerHealth pHealth;



    // Start is called before the first frame update
    void Start()
    {
        explosionDistanceGo.SetActive(false);
        StartCoroutine(Booom());
    }



    IEnumerator Booom()
    {
        yield return new WaitForSeconds(3f);
        explosionDistanceGo.SetActive(true);

        DestroyArea();

        Destroy(this.gameObject, 0.05f);
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
                    //    Collider2D overCollider2d = Physics2D.OverlapCircle(checkCellPos, 0.01f, whatisPlatform);
                    //     if (overCollider2d != null)
                    //    {
                    //         overCollider2d.transform.GetComponent<Ground>().MakeDot(checkCellPos);
                    //      }

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

        if (SplashRange > 0)
        {
            var hitColliders = Physics2D.OverlapCircleAll(transform.position, SplashRange);
            foreach (var hitCollider in hitColliders)
            {
                var enemy = hitCollider.GetComponent<Enemy>();
                var player = hitCollider.GetComponent<playerHealth>();
                if (enemy)
                {
                    enemy.TakeDamage(3);
                }
                else if (player)
                {
                    
                }
            }
        }
    }

    // Update is called once per frame
    // void Update()
    // {

    // }
}
