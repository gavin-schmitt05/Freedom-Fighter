using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splash : MonoBehaviour
{

    public GameObject explosionDistanceGo;

    public float SplashRange = 1;
    public float Damage = 1;
    public GameObject enemySprite;
    // Start is called before the first frame update
    void Update()
    {
        explosionDistanceGo.SetActive(false);
        StartCoroutine(Bomb());
    }



    IEnumerator Bomb()
    {

        yield return new WaitForSeconds(3f);
        explosionDistanceGo.SetActive(true);

      
        splashDamage();

      //  Destroy(this.gameObject, 0.05f);
    }

   public void splashDamage()
      {
       
        if (Vector3.Distance(enemySprite.transform.position, gameObject.transform.position) < 1)
       
        {         
            if (enemySprite.TryGetComponent<Enemy>(out Enemy enemyComponent))
            {
                enemyComponent.TakeDamage(3);
              //  var copy = Instantiate(enemySprite);
                //Destroy(copy);  
                enemySprite.SetActive(false);      
            }
      
        }
    
    }






    //   private void OnCollisonEnter2D(Collision2D collision)
    //   {
    //       if (SplashRange > 0)
    //      {
    //         var hitColliders = Physics2D.OverlapCircleAll(transform.position, SplashRange);
    //         foreach (var hitCollider in hitColliders)
    //          {
    //              var enemy = hitCollider.GetComponent<Enemy>();
    //              if (enemy)
    //               {
    //                  var closestPoint = hitCollider.ClosestPoint(transform.position);
    //                 var distance = Vector3.Distance(closestPoint, transform.position);

    //               var damagePercent = Mathf.InverseLerp(SplashRange, 0, distance);
    //            enemy.TakeDamage(damagePercent * Damage);
    //            }
    //         }
    // }

    //    else
    //    {
    //        var enemy = collision.collider.GetComponent<Enemy>();
    //      if (enemy)
    //        {
    //           enemy.TakeDamage(Damage);
    //     }
    //   }
    //   }

}
