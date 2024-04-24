using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableGunSlot2 : MonoBehaviour
{
    public GameObject gunSlot2;
    void Start()
    {
        gunSlot2.SetActive(false);
    }

}
