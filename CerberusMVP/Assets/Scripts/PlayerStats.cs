using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PlayerStats : MonoBehaviour {
    [Header("Player Stats")]
    public float Health = 100;
    public float maxHeath;
    public float Moxie = 100;
    public float moxieMax =100;
    public float Grit = 100;
    public float gritMax =100;

    [Header("UI Reference")]
    public TextMeshProUGUI healthUI;
    public TextMeshProUGUI moxieUI;
    public TextMeshProUGUI gritUI;

    public bool GritActive = false;

    // Start is called before the first frame update
    void Start() {
        PlayerManager.instance.stats = this;
    }

    // Update is called once per frame
    void Update() {
        Moxie += Time.deltaTime;
        Moxie = Mathf.Clamp(Moxie, 0, moxieMax);
        moxieUI.text = "Moxie: " + Moxie.ToString("F0");
                
        if(GritActive == false)
        {
            Grit += Time.deltaTime;
            Grit = Mathf.Clamp(Grit, 0, gritMax);
            Time.timeScale = 1f;
        }

        gritUI.text = "Grit: " + Grit.ToString("F0");

        if (Grit <= 0)
        {
            GritActive = false;
        }
    }

    public void TakeDamage(float damage) {

        Health -= damage;
        Mathf.Clamp(Health, 0, maxHeath);
        healthUI.text = "Health: " + Health;
        if (Health <= 0) {

        }
    }
}
