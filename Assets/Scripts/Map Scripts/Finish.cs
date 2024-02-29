using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private bool levelComplete = false;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelComplete)
        {
            levelComplete = true;
            Invoke("CompleteLevel", 0.25f);
        }
    }


    private void CompleteLevel()
    {
        DataPersistenceManager.instance.SaveGame();
        SceneManager.LoadScene(1);
    }
}

