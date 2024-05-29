using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInventoryManager2 : MonoBehaviour
{
    public WeaponInventorySlot2[] weaponInventorySlots2;
    public GameObject weaponInventoryItemPrefab;
    public GameObject gunSlot;
    public static WeaponInventoryManager2 instance;

    public void Awake()
    {
        instance = this;
    }

    public bool AddItem(Item item)
    {
        // Find any empty slot
        for (int i = 0; i < weaponInventorySlots2.Length; i++)
        {
            WeaponInventorySlot2 slot = weaponInventorySlots2[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null)
            {
                SpawnNewItem(item, slot);
                return true;
            }
        }

        return false;
    }

    void SpawnNewItem(Item item, WeaponInventorySlot2 slot)
    {
        GameObject newItemGo = Instantiate(weaponInventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
    }

    public void RemoveGun()
    {
         for (int i = 0; i < weaponInventorySlots2.Length; i++)
        {
            WeaponInventorySlot2 slot = weaponInventorySlots2[i];
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
