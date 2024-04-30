using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSlot : MonoBehaviour
{
    public static GunSlot instance;

    public GameObject Player; 
    
    public GameObject gunSlot;
    public void Awake()
    {
        instance = this;
        Player = GameObject.Find("Player");
    }
    public bool AddGun(GameObject item)
    {
        if (Player.transform.localScale == new Vector3(1, 1, 1))
        {
            gunSlot.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (Player.transform.localScale == new Vector3(-1, 1, 1))
        {
            gunSlot.transform.eulerAngles = new Vector3(0, 180, 0);
        }
        (Instantiate (item, gunSlot.transform.position, gunSlot.transform.rotation) as GameObject).transform.parent = gunSlot.transform;
        return true;
    }
}
