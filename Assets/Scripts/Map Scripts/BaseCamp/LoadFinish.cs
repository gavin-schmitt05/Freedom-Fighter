using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadFinish : MonoBehaviour
{
    private bool leave = false;

    private void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !leave)
        {
            leave = true;
            Invoke("LeaveLoad", 0.25f);
        }
    }


    private void LeaveLoad()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
