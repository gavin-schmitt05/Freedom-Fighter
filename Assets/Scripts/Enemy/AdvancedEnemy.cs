using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedEnemy : MonoBehaviour
{


    public float radius = 5f;
    [Range(1,360)]public float anlge = 45f;
    public LayerMask targetLayer;
    public LayerMask obstructionLayer;
    public GameObject playerRef;
    public bool CanSeePlayer { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVCheck());
    }



    // Update is called once per frame
    void Update()
    {
      
    }


    private IEnumerator FOVCheck()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FOV();
        }
    }
    private void FOV()
    {
        Collider2D[] rangeCheck = Physics2D.OverlapCircleAll(transform.position, radius, targetLayer);
        if (rangeCheck.Length > 0)
        {
            Transform target = rangeCheck[0].transform;
            Vector2 directionToTarget = (target.position - transform.position).normalized;
           
            if (Vector2.Angle(transform.rotation.y == 180? -transform.right : transform.right, directionToTarget) < anlge / 2)
            {
                float distanceToTarget = Vector2.Distance(transform.position, target.position);
                if (!Physics2D.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionLayer))
                {
                    CanSeePlayer = true;
                }
                else
                {
                    CanSeePlayer = false;
                }
            }
            else
            {
                CanSeePlayer = false;
            }
        }
        else if (CanSeePlayer)
        {
            CanSeePlayer = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.forward, radius);

        Vector3 angle01 = DirectionFromAngle(-anlge / 2);
        Vector3 angle02 = DirectionFromAngle(anlge / 2);

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + angle01 * radius);
        Gizmos.DrawLine(transform.position, transform.position + angle02 * radius);
        if (CanSeePlayer)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, playerRef.transform.position);

        }


    }

    private Vector2 DirectionFromAngle(float angleInDegrees)
    {
        return (Vector2)(Quaternion.Euler(0, 0, angleInDegrees) * (transform.rotation.y == 180 ? -transform.right : transform.right));
    }
}
