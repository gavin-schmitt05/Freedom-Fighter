using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechFlare : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject Mech;
    private GameObject airdropPoint;
    private float Speed = 4f;
    
    // Start is called before the first frame update
    void Start()
    {
        airdropPoint = GameObject.Find("Airdrop Point");
        rb.velocity = this.transform.right * Speed;
        StartCoroutine(MechDropper());
    }
    IEnumerator MechDropper()
    {
        Destroy(this.gameObject, 5);
        yield return new WaitForSeconds(4);
        airdropPoint.transform.position = new Vector3(this.gameObject.transform.position.x, 75, 0);
        Instantiate(Mech, airdropPoint.transform.position, airdropPoint.transform.rotation);
    }

}
