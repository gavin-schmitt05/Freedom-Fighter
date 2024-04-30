using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPersistence : MonoBehaviour
{
    public static CameraPersistence instance {get; private set;}
    private void Awake()
    { 
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Camera, destroying newest one");
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
}
