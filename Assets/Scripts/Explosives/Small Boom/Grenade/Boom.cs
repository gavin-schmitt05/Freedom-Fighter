using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class Boom : MonoBehaviour
{

    public GameObject explosionDistanceGo;
    public LayerMask whatisPlatform;
    public CircleCollider2D circleCollider2D;
    public GameObject enemySprite;

    public float SplashRange = 1;
    public float Damage;
    public playerHealth pHealth;
    public Animator anim;
    public Rigidbody2D nade;

    public float fuseLength;






    // Start is called before the first frame update
    void Start()
    {
        explosionDistanceGo.SetActive(false);
        StartCoroutine(Booom());
    }
    

   



      



    IEnumerator Booom()
    {
        Debug.Log("Booooooom created");
        yield return new WaitForSeconds(fuseLength);
        explosionDistanceGo.SetActive(true);
        
        
        DestroyArea();
        anim.SetBool("explode", true);
        nade.constraints = RigidbodyConstraints2D.FreezeAll;


        Destroy(this.gameObject, 0.6f);
        Debug.Log("test");
    }


    /*IEnumerator Checkboom()
    {
        yield return new WaitForSeconds(1f);
        yield return StartCoroutine(Booom());
        //AstarPath.active.Scan();
    }*/


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
                    Collider2D overCollider2d = Physics2D.OverlapCircle(checkCellPos, 0.01f, whatisPlatform);
                    if (overCollider2d != null)
                    {
                        overCollider2d.transform.GetComponent<Ground>().MakeDot(checkCellPos);
                    }

                    /*Collider2D[] overCollider2d = Physics2D.OverlapCircleAll(checkCellPos, 0.01f, whatisPlatform);
                    if (overCollider2d.Length > 0)
                    {
                        foreach (Collider2D overColl in overCollider2d)
                        {
                            overColl.GetComponent<Ground>().MakeDot(checkCellPos);
                            Debug.Log("played for each statement");
                            
                        }

                    }*/
                   
                }


            }
            
        }
        

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, SplashRange);
        
        foreach(Collider2D nearbyObject in colliders)
        {
            var obj = nearbyObject.GetComponent<Enemy>();
            var obs = nearbyObject.GetComponent<crateHealth>();
            var play = nearbyObject.GetComponent<playerHealth>();
            var dr = nearbyObject.GetComponent<doorHealth>();
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
         

        }





        
       // Debug.Log("test---------------->");
      

    }






    

 
}
