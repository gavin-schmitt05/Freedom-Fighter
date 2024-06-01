using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrow : MonoBehaviour
{
    Vector3 GrenadePosition;
    public LayerMask whatisPlatform;
    public GameObject boomClone;
    public GameObject Grenade;
    public Rigidbody2D rb;
    public GameObject Player;
    public playerHealth pHealth;
    public Transform ShootPoint;
    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;
    public Item itemRefrence;
    public Transform playerTransform;

   

    // Update is called once per frame
    void Update()
    {
        if (pHealth.health > 0)
        {
            if(Input.GetButtonDown("Grenade"))
            {
                if (playerTransform.localScale == new Vector3(1, 1, 1))
                {
                    ShootPoint.transform.eulerAngles = new Vector3(0, 0, 0);
                }
                else if (playerTransform.localScale == new Vector3(-1, 1, 1))
                {
                    ShootPoint.transform.eulerAngles = new Vector3(0, 180, 0);
                }
                for (int i = 0; i < inventorySlots.Length; i++)
                {
                    InventorySlot slot = inventorySlots[i];
                    InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
                    if (itemInSlot != null && itemInSlot.item == itemRefrence)
                    {
                        itemInSlot.count--;
                        if(itemInSlot.count <= 0)
                        {
                            Destroy(itemInSlot.gameObject);
                        }
                        itemInSlot.RefreshCount();
                        Instantiate(Grenade, ShootPoint.position, ShootPoint.rotation);                        Collider2D overCollider2d = Physics2D.OverlapCircle(GrenadePosition, 0.1f, whatisPlatform);
                        Debug.Log("Instantiated Grenade");
                        break;
                    }
                }
            }
                
          //  }
        }
            
    }
}

