using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSlotManager : MonoBehaviour
{
    public GameObject otherGunSlot;
    public GameObject thisGunSlot;
    void Update()
    {
        if (Input.GetKeyDown("1")){
            otherGunSlot.SetActive(true);
            thisGunSlot.SetActive(false);
        }
    }
}
