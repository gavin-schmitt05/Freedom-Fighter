using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour
{
    public GameObject g1;
    public GameObject g2;
    //respawns by resetting current scene
    public void ReloadCurrentScene()
    {
        Debug.Log("Button works");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    // respawns by switching scenes to base camp and then turning off death panel
    public void Respawn()
    {
        for (var i = g1.transform.childCount - 1; i >= 0; i--)
        {
            Object.Destroy(g1.transform.GetChild(i).gameObject);
        }
        for (var i = g2.transform.childCount - 1; i >= 0; i--)
        {
            Object.Destroy(g2.transform.GetChild(i).gameObject);
        }
        SceneManager.LoadScene("BaseCampTestScene");
        DataPersistenceManager.instance.NewGame();
        LevelManager.instance.GameOver();
    }
}
