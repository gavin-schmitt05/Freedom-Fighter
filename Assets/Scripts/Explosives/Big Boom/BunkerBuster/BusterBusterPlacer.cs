using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusterBusterPlacer : MonoBehaviour
{
    [SerializeField] private GameObject bunkerBusterMarker;
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            GameObject newBunkerBusterMarker = Instantiate(bunkerBusterMarker, new Vector3(this.transform.position.x + 1.0f, this.transform.position.y + .002f, 0), Quaternion.Euler(0, 0, 0));
            Destroy(newBunkerBusterMarker, 5);
            SpecialSlotInventoryManager.instance.RemoveSpecial(true);
            Destroy(this.gameObject);
        }
    }
}
