using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SwapWeapons : MonoBehaviour
{
    public Sprite Characters_7;
    public Sprite Characters_4;
    public Sprite Characters_12;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1")){
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Characters_4;
        }

        if (Input.GetKeyDown("2"))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Characters_7;
        }

        if (Input.GetKeyDown("3"))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Characters_12;
        }

    }
}
