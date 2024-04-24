using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInventoryManager1 : MonoBehaviour
{

    [SerializeField] public int maxStackedItems;
    public WeaponInventorySlot1[] weaponInventorySlots1;
    public GameObject weaponInventoryItemPrefab;
    public GameObject gunSlot;

    /*public void Awake()
    {
        instance = this;
    }*/

    public bool AddItem(Item item)
    {
        // Check if any slot has an item with count lower than max
        for (int i = 0; i < weaponInventorySlots1.Length; i++)
        {
            WeaponInventorySlot1 slot = weaponInventorySlots1[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null && itemInSlot.item == item && itemInSlot.count < itemInSlot.item.maxStackOfItem && itemInSlot.item.stackable == true)
            {
                itemInSlot.count++;
                itemInSlot.RefreshCount();
                return true;
            }
        }

        // Find any empty slot
        for (int i = 0; i < weaponInventorySlots1.Length; i++)
        {
            WeaponInventorySlot1 slot = weaponInventorySlots1[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null)
            {
                SpawnNewItem(item, slot);
                return true;
            }
        }

        return false;
    }

    void SpawnNewItem(Item item, WeaponInventorySlot1 slot)
    {
        GameObject newItemGo = Instantiate(weaponInventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
    }
}
