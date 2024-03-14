using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInventoryManager : MonoBehaviour
{
    //

    [SerializeField] public int maxStackedItems;
    public WeaponInventorySlot[] weaponInventorySlots;
    public GameObject weaponInventoryItemPrefab;

    /*public void Awake()
    {
        instance = this;
    }*/

    public bool AddItem(Item item)
    {
        // Check if any slot has an item with count lower than max
        for (int i = 0; i < weaponInventorySlots.Length; i++)
        {
            WeaponInventorySlot slot = weaponInventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null && itemInSlot.item == item && itemInSlot.count < maxStackedItems && itemInSlot.item.stackable == true)
            {
                itemInSlot.count++;
                itemInSlot.RefreshCount();
                return true;
            }
        }

        // Find any empty slot
        for (int i = 0; i < weaponInventorySlots.Length; i++)
        {
            WeaponInventorySlot slot = weaponInventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null)
            {
                SpawnNewItem(item, slot);
                return true;
            }
        }

        return false;
    }

    void SpawnNewItem(Item item, WeaponInventorySlot slot)
    {
        GameObject newItemGo = Instantiate(weaponInventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
    }
}
