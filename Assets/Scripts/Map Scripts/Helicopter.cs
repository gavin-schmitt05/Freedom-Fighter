using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Helicopter : MonoBehaviour
{

    private Rigidbody2D heli;

    public float speed = 5f;
    public float height = 2f;

    bool heliCollided = false;
    public BoxCollider2D collider;
    public GameObject Player;
    public HeliLower heliLower;


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
            StartCoroutine(change());
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            heliCollided = true;
            Player.SetActive(false);
            CameraController.instance.changeCamera(this.transform);
            heliLower.enabled = false;
        }

    }

     IEnumerator change()
    {
        Debug.Log("changing now !!!!!!!!!!!!!");
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("BaseCampTestScene");
    }





}
