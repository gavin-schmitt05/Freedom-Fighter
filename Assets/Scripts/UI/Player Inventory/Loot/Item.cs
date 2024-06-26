using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable object/Item")]
public class Item : ScriptableObject {
    
    [Header("Only gameplay")] 
    public ItemType type;
    public ActionType actionType;
    public GameObject itemPrefab;
    public Vector2Int range = new Vector2Int(5, 4);

    [Header("Only UI")]
    public bool stackable = true;
    public bool isGun = true;
    public bool isSpecial = false;
    public int maxStackOfItem;

    [Header("Both")]
    public Sprite image;
}

public enum ItemType
{
    Gun,
    Coin,
    Grenade,
    HealthPack,
    Ammo,
    Airdrop,
    Bomb,

}

public enum ActionType
{
    Weapon,
    Money,
    Consumables,
    Support,
}
