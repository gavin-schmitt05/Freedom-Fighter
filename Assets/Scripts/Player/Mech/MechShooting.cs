using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechShooting : MonoBehaviour
{
    public GameObject mechBody;

    public GameObject Bullet;
    public Rigidbody2D rb;
    [HideInInspector] private GameObject player;
    public Animator anim;
    
    
    //Audio - not needed at moment
    //public AudioSource audioSource;
    //public AudioClip shootingAudioClip;

    public Transform ShootPoint;
    public float FireRate;
    float ReadyForShot;
    public float direction = 0f;
    
    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        direction = Input.GetAxis("Horizontal");

        if (Input.GetMouseButton(0))
        {
            if (player.activeInHierarchy == false)
            {
                if (mechBody.transform.localScale == new Vector3(-1, 1, 1))
                {
                    ShootPoint.transform.eulerAngles = new Vector3(0, 0, 0);
                }
                else if (mechBody.transform.localScale == new Vector3(1, 1, 1))
                {
                    ShootPoint.transform.eulerAngles = new Vector3(0, 180, 0);
                }
                if (Time.time > ReadyForShot)
                {
                    ReadyForShot = Time.time + 1 / FireRate;
                    shoot();
                }
            }
        }
        else
        {
            anim.SetBool("shooting", false);
        }
    }

    void shoot()
    {
        //audioSource.PlayOneShot(shootingAudioClip); // will add back when I need audio for mech
        anim.SetBool("shooting", true);
        GameObject BulletIns = Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);
        Destroy(BulletIns, 3);
    } 
}
