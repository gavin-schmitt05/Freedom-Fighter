using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    [Header("UI")]
    public Image image;
    public Text countText;

    [HideInInspector] public Item item;
    [HideInInspector] public int count = 1;
    [HideInInspector] public Transform parentAfterDrag;

    public void Start()
    {
        RefreshCount();
    }

    public void InitialiseItem(Item newItem)
    {
        item = newItem;
        image.sprite = newItem.image;
        RefreshCount();
    }

    public void RefreshCount()
    {
        countText.text = count.ToString();
        bool textActive = count > 1;
        countText.gameObject.SetActive(textActive);
    }

    //Drag and drop
    public void OnBeginDrag(PointerEventData eventData)
    {
        countText.raycastTarget = false;
        image.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        countText.raycastTarget = true;
        image.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
        if(item.isGun == true){
            WeaponInventoryManager1.instance.RemoveGun();
            WeaponInventoryManager2.instance.RemoveGun();
        }
        else if(item.isSpecial == true)
        {
            SpecialSlotInventoryManager.instance.RemoveSpecial(false);
        }
    }
}
