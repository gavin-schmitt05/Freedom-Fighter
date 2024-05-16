using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechFlare : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject Mech;
    public GameObject airdropPoint;
    private float Speed = 4f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = this.transform.right * Speed;
        StartCoroutine(MechDropper());
    }
    IEnumerator MechDropper()
    {
        Destroy(this, 3);
        yield return new WaitForSeconds(4f);
        airdropPoint.transform.eulerAngles = new Vector3(airdropPoint.transform.eulerAngles.x, airdropPoint.transform.eulerAngles.y, airdropPoint.transform.eulerAngles.z = 0);
        Instantiate(Mech, airdropPoint.position, airdropPoint.rotation);
    }

}
