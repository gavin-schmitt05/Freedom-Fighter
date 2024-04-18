using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    //public GameObject inventory;
    private bool levelComplete = false;
    public static Finish instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Finish, destroying newest one");
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {

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
        //inventory.transform.SetParent(null);
        SceneManager.LoadScene(2);
    }
}

