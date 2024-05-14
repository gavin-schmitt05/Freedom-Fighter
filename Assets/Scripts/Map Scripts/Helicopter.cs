using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour
{

    private Rigidbody2D heli;

    public float speed = 5f;
    public float height = 2f;

    bool heliCollided = false;
    public BoxCollider2D collider;
    public GameObject Player;


    // Start is called before the first frame update
    void Start()
    {
        heli = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (heliCollided)
        {
            heli.velocity = new Vector2(speed, height);
            
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collison)
    {

        if (collison.tag == "Player")
        {
            heliCollided = true;
            Player.SetActive(false);
            CameraController.instance.changeCamera(this.transform);

        }

    }





}
