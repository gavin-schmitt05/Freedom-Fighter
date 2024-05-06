using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("Menu buttons")]
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button continueGameButton;
    [SerializeField] private Button levelOneButton;
    [SerializeField] private Button levelTwoButton;

    private void Start()
    {
        if (!DataPersistenceManager.instance.HasGameData())
        {
            continueGameButton.interactable = false;
        }
    }

    public void OnNewGameClicked()
    {
        DisableMenuButtons();
        DataPersistenceManager.instance.NewGame();

        SceneManager.LoadSceneAsync("LucianScene");
        //implement once main menu isnt needed for testing
        //SceneManager.LoadSceneAsync("LoadingScene");
    }

    public void OnContinueClicked()
    {
        DisableMenuButtons();
        SceneManager.LoadSceneAsync("LucianScene");
        //implement once main menu isnt needed for testing
        //SceneManager.LoadSceneAsync("LoadingScene");
    }

    public void OnLevelSelectOne()
    {
        DisableMenuButtons();
        SceneManager.LoadScene(1);
    }
        public void OnLevelSelectTwo()
    {
        DisableMenuButtons();
        SceneManager.LoadScene(2);
    }
    private void DisableMenuButtons()
    {
        newGameButton.interactable = false;
        continueGameButton.interactable = false;
        levelOneButton.interactable = false;
        levelTwoButton.interactable = false;
    }
}
