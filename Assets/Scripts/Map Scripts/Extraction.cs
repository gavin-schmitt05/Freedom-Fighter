using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extraction : CollidableObject
{
    private bool z_Interacted = false;

    public GameObject EnemySpawner;

  //  public Timer time;

    public GameObject Timer;

    public Timer timeAmount;

    public GameObject extractionZone;
    public LayerMask whatisPlayer;

    public float range = 1;
    




    public CircleCollider2D circleCollider2D;


    



    protected override void OnCollided(GameObject collidedObject)
    {
        if (Input.GetKey(KeyCode.E))
        {
            OnInteract();
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

            
        } 

        //if (timeAmount.remainingTime == 0 )
       // {
       //     EnemySpawner.SetActive(false);
        //    Timer.SetActive(false);
       // }       
    }


    void zoneChecker()
    {
      //  Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, range);
      //   foreach(Collider2D nearbyObject in colliders)
       // {
           
        //    var play = nearbyObject.GetComponent<playerHealth>();
          //  if (play == null)
       //     {
                
        //    }

       // }
    }



}
