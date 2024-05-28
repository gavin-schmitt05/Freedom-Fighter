using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WeaponInventorySlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        InventoryItem InventoryItem = dropped.GetComponent<InventoryItem>();
        if (transform.childCount == 0)
        {
            if(InventoryItem.item.isGun == true)
            {
                InventoryItem.parentAfterDrag = transform;
                bool canAddGun = GunSlot.instance.AddGun(InventoryItem.item.itemPrefab);
                if(canAddGun){
                }
                else{
                }
            }
        }
    }
}
