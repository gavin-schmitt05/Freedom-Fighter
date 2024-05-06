using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechDrop : MonoBehaviour
{
    [Header("Inventory")]
    public Item itemReference;
    public InventorySlot[] inventorySlots;
    public GameObject invetoryItemPrefab;

    [Header("Mech")]
    public GameObject Mech;
    private Transform airdropPoint;

    private Rigidbody2D rb;
    public Transform flareShootPoint;
    public float Speed = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("4"))
        {
            rb = itemReference.itemPrefab.GetComponent<Rigidbody2D>();
            rb.velocity = transform.right * Speed;
            Instantiate(itemReference.itemPrefab, transform.position, transform.rotation);
            new WaitForSeconds(2.5f);
            airdropPoint.position = new Vector3(itemReference.itemPrefab.transform.position.x, 75.0f, itemReference.itemPrefab.transform.position.z);
            Instantiate(Mech, airdropPoint.position, airdropPoint.rotation);
            /*for (int i = 0; i < inventorySlots.Length; i++)
            {
                InventorySlot slot = inventorySlots[i];
                InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
                if (itemInSlot != null && itemInSlot.item == itemReference)
                {
                    itemInSlot.count--;
                    Destroy(itemInSlot.gameObject);
                    itemInSlot.RefreshCount();

                    pHealth.health += 30f;




                    break;
                }
            }*/

        }
    }
}
