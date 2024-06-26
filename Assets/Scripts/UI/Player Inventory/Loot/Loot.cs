using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Loot : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Item itemToPickup;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            bool canAdd = InventoryManager.instance.AddItem(itemToPickup);

            if (canAdd)
            {
                StartCoroutine(MoveAndCollect(other.transform));
            }
        }
    }

    private IEnumerator MoveAndCollect(Transform target)
    {
        Destroy(gameObject);
        yield return 0;
    }
}
