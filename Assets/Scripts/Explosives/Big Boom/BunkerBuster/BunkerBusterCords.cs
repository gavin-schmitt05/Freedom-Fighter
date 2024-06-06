using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunkerBusterCords : MonoBehaviour
{
    [SerializeField] private GameObject newBunkerBuster;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(dropBunkerBuster());
    }

    IEnumerator dropBunkerBuster()
    {
        yield return new WaitForSeconds(3);
        Instantiate(newBunkerBuster, new Vector3(this.transform.position.x, this.transform.position.y + 50, 0), this.transform.rotation);
    }
}
