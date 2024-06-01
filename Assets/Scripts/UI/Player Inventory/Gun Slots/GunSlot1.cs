using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSlot1 : MonoBehaviour
{
    public static GunSlot1 instance;

    public GameObject Player; 

    public void Awake()
    {
        instance = this;
        Player = GameObject.Find("Player");
    }
    public void AddGun(GameObject item)
    {
        if (Player.transform.localScale == new Vector3(1, 1, 1))
        {
            this.gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (Player.transform.localScale == new Vector3(-1, 1, 1))
        {
            this.gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
        }
        (Instantiate (item, this.gameObject.transform.position, this.gameObject.transform.rotation) as GameObject).transform.parent = this.gameObject.transform;
    }
}
