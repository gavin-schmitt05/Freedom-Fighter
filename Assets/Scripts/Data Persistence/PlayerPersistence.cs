using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPersistence : MonoBehaviour
{
    public static PlayerPersistence instance {get; private set;}
    private void Awake()
    { 
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Player, destroying newest one");
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
}
