using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData 
{
    public int temp;
    public Vector3 playerPosition;

    public GameData()
    {
        this.temp = 0;
        playerPosition = new Vector3(-18, 2, 0);
    }
}
