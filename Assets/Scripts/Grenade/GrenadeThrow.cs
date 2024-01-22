using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrow : MonoBehaviour
{
    Vector3 GrenadePosition;
    public LayerMask whatisPlatform;
    public GameObject boomClone;
    public GameObject Grenade;
    public Rigidbody2D rb;
    public GameObject Player;
    public playerHealth pHealth;
    public Transform ShootPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pHealth.health > 0)
        {
            if (Input.GetButtonDown("Grenade"))
            {
                
                Instantiate(Grenade, ShootPoint.position, ShootPoint.rotation);
                Collider2D overCollider2d = Physics2D.OverlapCircle(GrenadePosition, 0.1f, whatisPlatform);
              
            }
        }
        }
    }

