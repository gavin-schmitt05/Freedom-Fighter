using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WeaponInventorySlot : MonoBehaviour, IDropHandler
{
    public InventoryItem inventoryItem;

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            if(inventoryItem.item.stackable == false)
            {
                GameObject dropped = eventData.pointerDrag;
                InventoryItem InventoryItem = dropped.GetComponent<InventoryItem>();
                InventoryItem.parentAfterDrag = transform;
            }
        }
    }
}
