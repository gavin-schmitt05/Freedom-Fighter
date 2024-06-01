using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableGunSlots : MonoBehaviour
{
    // This script makes it so the gun/special slot that is disabled actually load when the game first starts, then deactivates as wanted
    public GameObject gunSlot2;
    public GameObject specialSlot;
    void Start()
    {
        gunSlot2.SetActive(false);
        specialSlot.SetActive(false);
    }

}
