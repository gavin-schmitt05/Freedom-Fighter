using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvas : MonoBehaviour
{
    public static canvas instance { get; private set; }
     private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one canvas, destroying newest one");
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
}
