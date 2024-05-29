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
            // Try to get the ISpecialSlotItem component from the current slot
            var specialSlotInterface = thisGunSlot.GetComponentInChildren<ISpecialSlotInterface>();

            // If the component exists, call the OnDeactivate method
            if (specialSlotInterface != null)
            {
                specialSlotInterface.OnDeactivate();
            }

            otherGunSlot.SetActive(true);
            thisGunSlot.SetActive(false);
        }
    }
}
