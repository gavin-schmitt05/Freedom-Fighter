using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp : MonoBehaviour, IDataPersistence
{
    private int temp = 0;

    void Start()
    {
        
    }

    public void LoadData(GameData data)
    {
        this.temp = data.temp;
    }
    
    public void SaveData(ref GameData data)
    {
        data.temp = this.temp;
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            temp++;
        }
    }
}
