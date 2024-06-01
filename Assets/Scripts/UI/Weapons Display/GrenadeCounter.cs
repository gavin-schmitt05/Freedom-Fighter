using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  TMPro;

public class GrenadeCounter : MonoBehaviour
{
    public static GrenadeCounter instance;

    public TMP_Text grenadeText;
    public int currentGrenade = 5;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        grenadeText.text = currentGrenade.ToString();
    }

    public void DecreaseCount(int grenade)
    {
        currentGrenade -= grenade;
        grenadeText.text = currentGrenade.ToString();
    }

        public void IncreaseCount(int grenade)
    {
        currentGrenade += grenade;
        grenadeText.text = currentGrenade.ToString();
    }
}
