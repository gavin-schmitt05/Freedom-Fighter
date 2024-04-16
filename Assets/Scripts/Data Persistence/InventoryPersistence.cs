using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPersistence : MonoBehaviour
{

    public static InventoryPersistence instance { get; private set; }

   private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one data persistence manager, destroying newest one");
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
