using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInventoryManager1 : MonoBehaviour
{
    public WeaponInventorySlot1[] weaponInventorySlots1;
    public GameObject weaponInventoryItemPrefab;
    public GameObject gunSlot;
    public static WeaponInventoryManager1 instance;

    public void Awake()
    {
        instance = this;
    }

    public bool AddItem(Item item)
    {
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

    public void RemoveGun()
    {
         for (int i = 0; i < weaponInventorySlots1.Length; i++)
        {
            WeaponInventorySlot1 slot = weaponInventorySlots1[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null )
            {
                foreach (Transform child in gunSlot.transform)
                {
                Destroy(child.gameObject);
                }
            }
        }
    }
}
