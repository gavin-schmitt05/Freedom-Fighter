using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSlot : MonoBehaviour
{
    public static GunSlot instance;
    
    public GameObject gunSlot;
    public void Awake()
    {
        instance = this;
    }
    public bool AddGun(GameObject item)
    {
        (Instantiate (item, gunSlot.transform.position, gunSlot.transform.rotation) as GameObject).transform.parent = gunSlot.transform;
        Debug.Log("Instantiated gun");
        return true;
    }
}
