using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrow : MonoBehaviour
{

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

        }
    }
}
