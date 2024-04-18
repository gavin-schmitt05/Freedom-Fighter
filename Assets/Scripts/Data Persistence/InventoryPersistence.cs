using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPersistence : MonoBehaviour
{
    public static InventoryPersistence instance {get; private set;}
    private void Awake()
    { 
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Inventory Persistence, destroying newest one");
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

}
