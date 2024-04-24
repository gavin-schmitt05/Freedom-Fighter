using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasPersistence : MonoBehaviour
{
    public static CanvasPersistence instance {get; private set;}
    private void Awake()
    { 
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Canvas Persistence, destroying newest one");
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
}
