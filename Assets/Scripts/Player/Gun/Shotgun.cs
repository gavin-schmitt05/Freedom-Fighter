using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{

    [SerializeField] private AmmoCount ammoCount;
    [SerializeField] private Rigidbody2D ShotgunBullet;


    public float Max;
    public float Current;
    private float BulletSpeed = 500f;


   
    public Rigidbody2D rb;
    public GameObject player;
   

    public Transform ShootPoint;
    public float FireRate;
    float ReadyForShot;
    public float direction = 0f;
    public playerHealth pHealth;
    //public GameObject Inventory;


    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("Player");

        
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


        if (Input.GetKeyDown("r")) 
        {
            Current = Max;
            ammoCount.UpdateHealthBar(Current, Max);
        }


        if (pHealth.health > 0)
        {
            if (Current > 0)
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


    } 

    void shoot()
    {
        for (int i = 0; i <= 2; i++)
        {
        var BulletIns = Instantiate(ShotgunBullet, ShootPoint.position, ShootPoint.rotation);

        switch (i)
        {
            case 0:
            BulletIns.AddForce(ShootPoint.up  + new Vector3(0f, -90f, 0f));
            break;
            case 1:
            BulletIns.AddForce(ShootPoint.up  + new Vector3(0f, 0f, 0f));
            break;
            case 2:
            BulletIns.AddForce(ShootPoint.up  + new Vector3(0f, 90f, 0f));
            break;
        }


        Destroy(BulletIns, 3);
        ammoCount.UpdateHealthBar(Current--, Max);
        }
       
        
    }
}

