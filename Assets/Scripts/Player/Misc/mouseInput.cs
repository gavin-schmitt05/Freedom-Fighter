using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseInput : MonoBehaviour
{
    
    Vector3 MousePosition;
    public LayerMask whatisPlatform;
    public GameObject boomClone;

    // Start is called before the first frame update
//    void Start()
 //   {
        
  //  }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(MousePosition, 0.2f);
    }

    // Update is called once per frame




    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D overCollider2d = Physics2D.OverlapCircle(MousePosition, 0.1f, whatisPlatform);
            if (overCollider2d != null)
            {
                overCollider2d.transform.GetComponent<Ground>().MakeDot(MousePosition);            }
            }

        else if (Input.GetMouseButtonDown(1))
        {
            MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(boomClone, MousePosition, Quaternion.identity);

        }
    }
}
