using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoScript : MonoBehaviour
{
    public EnemyInventoryManager EnemyInventoryManager;
    public Item[] itemsToPickup;

    public void Randomize()
    {
        int randomNumber = Random.Range(0, 2);
        Debug.Log(randomNumber);
        EnemyInventoryManager.AddItem(itemsToPickup[randomNumber]);
    }
}
