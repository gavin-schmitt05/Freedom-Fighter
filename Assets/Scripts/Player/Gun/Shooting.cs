using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shooting : MonoBehaviour
{

    public GameObject Bullet;
    public Rigidbody2D rb;
    public GameObject player;
   
    public Transform ShootPoint;
    public float FireRate;
    float ReadyForShot;
    public float direction = 0f;
    public playerHealth pHealth;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = Input.GetAxis("Horizontal");

        if (player.transform.localScale == new Vector3(1, 1, 1))
        {
            ShootPoint.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (player.transform.localScale == new Vector3(-1, 1, 1))
        {
            ShootPoint.transform.eulerAngles = new Vector3(0, 180, 0);
        }




        if (pHealth.health > 0)
        {
            if (Input.GetMouseButton(0))
            {
                if (Time.time > ReadyForShot)
                {
                    ReadyForShot = Time.time + 1 / FireRate;
                    shoot();
                }

            }
        }
       
    }


    void shoot()
    {
      

        GameObject BulletIns = Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);
       
        Destroy(BulletIns, 3);
    }
}
