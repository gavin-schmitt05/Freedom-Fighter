using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class TileDestoyer : MonoBehaviour
{

    public Tilemap tilemap;

    void Start()
    {
        tilemap = GetComponent<Tilemap>();
    }

    public void MakeDot (Vector3 Pos)
    {
        Vector3Int cellPosition = tilemap.WorldToCell(Pos);
        tilemap.SetTile(cellPosition, null);
    }
    
    
}
