using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public float health;
    public float maxHeatlth;
    public Image healthBar;
    // Start is called before the first frame update

    void Start()
    {
        maxHeatlth = health;

    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHeatlth, 0, 1);
    }
}
