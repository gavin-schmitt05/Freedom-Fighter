using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeExplosion : MonoBehaviour
{
   
    public float impactField;
    
    public float Speed = 4;
    public Rigidbody2D rb;
  
    



    // Start is called before the first frame update
    void Start()
    {
        
        rb.velocity = transform.right * Speed;
     //   explosionDistanceGo.SetActive(false);
    //    StartCoroutine(Booom());
    }

    // Update is called once per frame
  //  void Update()
 //   {
  //      GrenadeTimer -= Time.deltaTime;
  //      if (GrenadeTimer <= 0)
  //      {
            
    //        explode();
            
    //    }
  //  }
    

 //   void explode()
  //  {
  //     Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, impactField, LayerToHit);


   //     foreach(Collider2D obj in objects)
     //   {
        //    Vector2 direction = obj.transform.position - transform.position;

    //        obj.GetComponent<Rigidbody2D>().AddForce(direction * force);
   //     }

        
   //     Destroy(gameObject, 1);
        
 //   }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, impactField);
    }


 //   IEnumerator Booom()
 //   {
  //      yield return new WaitForSeconds(3f);
    //    explosionDistanceGo.SetActive(true);

   //     DestroyArea();

   //     Destroy(this.gameObject, 0.05f);
  //  }


  //  void DestroyArea()
  //  {
      //  int radiusInt = Mathf.RoundToInt(circleCollider2D.radius);
       // for (int i = -radiusInt; i <= radiusInt; i++)
       // {
         //   for (int j = -radiusInt; j <= radiusInt; j++)
        //    {
           //     Vector3 checkCellPos = new Vector3(transform.position.x + i, transform.position.y + j, 0);
            //    float distance = Vector2.Distance(transform.position, checkCellPos) - 0.001f;
            //    if (distance <= radiusInt)
             //   {
                    //    Collider2D overCollider2d = Physics2D.OverlapCircle(checkCellPos, 0.01f, whatisPlatform);
                    //     if (overCollider2d != null)
                    //    {
                    //         overCollider2d.transform.GetComponent<Ground>().MakeDot(checkCellPos);
                    //      }

              //      Collider2D[] overCollider2d = Physics2D.OverlapCircleAll(checkCellPos, 0.01f, whatisPlatform);
               //     if (overCollider2d.Length > 0)
                //    {
                 //       foreach (Collider2D overColl in overCollider2d)
                 //       {
                  //          overColl.GetComponent<Ground>().MakeDot(checkCellPos);
                  //      }

                  //  }
             //   }


         //   }
        //}



   //     private void OnCollisonEnter2D(Collision2D collision)
 //   {
    //    if (SplashRange > 0)
    //    {
       //     var hitColliders = Physics2D.OverlapCircleAll(transform.position, SplashRange);
     //       foreach (var hitCollider in hitColliders)
       //     {
      //          var enemy = hitCollider.GetComponent<Enemy>();
      //          if (enemy)
     //           {
     //               enemy.TakeDamage(3);
    //            }
      //      }
     //   }
 //   }
    }






