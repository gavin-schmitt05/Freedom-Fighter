using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechDrop : MonoBehaviour
{
    [Header("Inventory")]
    public Item itemReference;
    public InventorySlot[] inventorySlots;
    public GameObject invetoryItemPrefab;

    [Header("Mech")]
    public GameObject Mech;
    public Transform airdropPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("4"))
        {
            Instantiate(Mech, airdropPoint.position, airdropPoint.rotation);
            /*for (int i = 0; i < inventorySlots.Length; i++)
            {
                InventorySlot slot = inventorySlots[i];
                InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
                if (itemInSlot != null && itemInSlot.item == itemReference)
                {
                    itemInSlot.count--;
                    Destroy(itemInSlot.gameObject);
                    itemInSlot.RefreshCount();

                    pHealth.health += 30f;




                    break;
                }
            }*/

        }
    }
}
