using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialSlotInventoryManager : MonoBehaviour
{
    public SpecialInventorySlot[] specialInventorySlots;
    public GameObject specialInventoryItemPrefab;
    public GameObject specialSlot;
    public static SpecialSlotInventoryManager instance;


    public void Awake()
    {
        instance = this;
    }

    public bool AddItem(Item item)
    {
        // Find any empty slot
        for (int i = 0; i < specialInventorySlots.Length; i++)
        {
            SpecialInventorySlot slot = specialInventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null)
            {
                SpawnNewItem(item, slot);
                return true;
            }
        }

        return false;
    }

    void SpawnNewItem(Item item, SpecialInventorySlot slot)
    {
        GameObject newItemGo = Instantiate(specialInventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
    }

    public void RemoveSpecial(bool airstrikeUsed)
    {
        for (int i = 0; i < specialInventorySlots.Length; i++)
        {
            SpecialInventorySlot slot = specialInventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null)
            {
                foreach (Transform child in specialSlot.transform)
                {
                    Destroy(child.gameObject);
                }
            }
            else if (airstrikeUsed)
            {
                itemInSlot.count--;
                if (itemInSlot.count <= 0)
                {
                    Destroy(itemInSlot.gameObject);
                }
            }
        }
    }
}
