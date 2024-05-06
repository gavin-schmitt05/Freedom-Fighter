using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathPanel : MonoBehaviour
{
    [Header("Respawn button")]
    [SerializeField] private Button respawnButton;

    public void OnRespawnButtonClicked()
    {
        SceneManager.LoadSceneAsync("BaseCampTestScene");
    }
}
