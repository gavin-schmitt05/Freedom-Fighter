using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour
{
    //respawns by resetting current scene
    public void ReloadCurrentScene()
    {
        Debug.Log("Button works");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    // respawns by switching scenes to base camp and then turning off death panel
    public void Respawn()
    {
        SceneManager.LoadScene("LoadingScene");
        DataPersistenceManager.instance.NewGame();
        LevelManager.instance.GameOver();
    }
}
