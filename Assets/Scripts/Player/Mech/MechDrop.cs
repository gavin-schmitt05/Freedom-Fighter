using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechDrop : MonoBehaviour
{
    [Header("Inventory")]
    public Item itemReference;
    public InventorySlot[] inventorySlots;
    public GameObject invetoryItemPrefab;

    public Transform flareShootPoint;
    public Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("4"))
        {
            for (int i = 0; i < inventorySlots.Length; i++)
            {
                InventorySlot slot = inventorySlots[i];
                InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
                if (itemInSlot != null && itemInSlot.item == itemReference)
                {
                    // Inventory
                    itemInSlot.count--;
                    Destroy(itemInSlot.gameObject);
                    itemInSlot.RefreshCount();
                    
                    if (playerTransform.localScale == new Vector3(1, 1, 1))
                    {
                        flareShootPoint.transform.eulerAngles = new Vector3(0, 0, 0);
                    }
                    else if (playerTransform.localScale == new Vector3(-1, 1, 1))
                    {
                        flareShootPoint.transform.eulerAngles = new Vector3(0, 180, 0);
                    }
                    Instantiate(itemReference.itemPrefab, flareShootPoint.position, flareShootPoint.rotation);
                    break;
                }
            }

        }
    }
}
