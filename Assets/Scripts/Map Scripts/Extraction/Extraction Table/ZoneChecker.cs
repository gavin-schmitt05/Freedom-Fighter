using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneChecker : MonoBehaviour
{


    public float range = 10;

    public Timer timeAmount;

    public GameObject Timer;

    public Extraction Extract;

 
    public LayerMask targetLayer;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Checker();
    }








    void Checker()
   {

        if(Timer.activeSelf)
        {

            
        Collider2D[] rangeCheck = Physics2D.OverlapCircleAll(transform.position, range, targetLayer);
        if (rangeCheck.Length > 0)
        {
            Transform target = rangeCheck[0].transform;
            Vector2 directionToTarget = (target.position - transform.position).normalized;
           
            
        }
        else 
        {
           Timer.SetActive(false);
           Extract.z_Interacted = false;
           Extract.EnemySpawner.SetActive(false);
        }
        }



    }
}
