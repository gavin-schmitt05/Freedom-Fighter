using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    public static Timer instance;

    void Awake()
    {
        instance = this; // Creates instance of script to be accessed from anywhere
    }

    // Start is called before the first frame update
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] public float remainingTime;

    public Extraction Extract;
    public GameObject Extraction;
    public GameObject heli;
    private GameObject newHeli;

    // Update is called once per frame
    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }

        else if (remainingTime < 0)
        {
            newHeli = Instantiate(heli, heli.transform.position = new Vector3(Extraction.transform.position.x, 55, 0), heli.transform.rotation);
            remainingTime = 0;
            Extract.z_Interacted = false;
            Extract.EnemySpawner.SetActive(false);
        }
        else if (remainingTime == 0)
        {
            newHeli.transform.position = Vector2.Lerp(newHeli.transform.position, new Vector3(Extraction.transform.position.x, 5, 0), Time.deltaTime / 2);
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void disableTimer(bool isDisabled)
    {
        this.gameObject.SetActive(isDisabled);
    }
}
