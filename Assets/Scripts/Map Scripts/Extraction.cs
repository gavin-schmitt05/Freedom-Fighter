using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Extraction : CollidableObject
{
    public bool z_Interacted = false;

    public GameObject EnemySpawner;



    public GameObject Timer;

    public Timer timeAmount;

    public GameObject extractionZone;
    public LayerMask whatisPlayer;

   // public float range = 1;

    public bool checkStart = false;
    




    public CircleCollider2D circleCollider2D;




 





   


    



    protected override void OnCollided(GameObject collidedObject)
    {
                Debug.Log("????????????????????");

        if (Input.GetKey(KeyCode.E))
        {
            OnInteract();
            Debug.Log("BYEE&&&&&&&&&&&&&&&&&&&");
        }
    }

    protected virtual void OnInteract()
    {
        if (!z_Interacted)
        {
            z_Interacted = true;
            Debug.Log("INTERACT WITH " + name);
            EnemySpawner.SetActive(true);
            Timer.SetActive(true);
            checkStart = true;
            AstarPath.active.Scan();

            
        } 

        //if (timeAmount.remainingTime == 0 )
       // {
       //     EnemySpawner.SetActive(false);
        //    Timer.SetActive(false);
       // }       
    }


 //   void zoneChecker()
  //  {

    //    if(Timer.activeSelf)
      //  {
          //  if(timeAmount.remainingTime <= 0)
          //  {
          //      Timer.SetActive(false);
          //  }

        //    Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, range);
          //  foreach(Collider2D nearbyObject in colliders)
        //    {
           
        //        var play = nearbyObject.GetComponent<playerHealth>();
        //        if (play != null)
        //        {
        //            Debug.Log("player is in radius");
                
        //        }

                

        //    }
    //    }
 //   }



}
