
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {
    [Header("Player Stats")]
    static public float Health = 100;
    public float maxHeath;
    static public float Moxie = 100;
    public float moxieMax = 100;
    static public float Grit = 100;
    public float gritMax =100;
    public float gold = 100;

    [Header("UI Reference")]
    public TextMeshProUGUI healthText;
    public Image healthBar;
    public TextMeshProUGUI moxieText;
    public Image MoxieBar;
    public TextMeshProUGUI gritText;
    public Image GritBar;
    public TextMeshProUGUI ammoClip, ammoTotal;
    public bool GritActive = false;
    public Gun activeGun;

    private void Start() {
        PlayerManager.instance.stats = this;
    }

    // Update is called once per frame
    void Update() {
        Moxie += Time.deltaTime;
        Moxie = Mathf.Clamp(Moxie, 0, moxieMax);
        UpdateMoxxiUI();
        
                
        if(GritActive == false)
        {
            Grit += Time.deltaTime;
            Grit = Mathf.Clamp(Grit, 0, gritMax);
            Time.timeScale = 1f;
        }
        UpdateGritUI();
        

        if (Grit <= 0)
        {
            GritActive = false;
        }
        if(activeGun != null) {
            ammoClip.text = activeGun.ammoInClip.ToString();
            ammoTotal.text = activeGun.currentAmmo.ToString();
            ammoClip.gameObject.SetActive(true);
            ammoTotal.gameObject.SetActive(true);
        }
        else {
            ammoClip.gameObject.SetActive(false);
            ammoTotal.gameObject.SetActive(false);
        }

       
    }

    public void TakeDamage(float damage) {

        Health -= damage;
        Mathf.Clamp(Health, 0, maxHeath);
        UpdateHealthUI();
        
        if (Health <= 0) {

        }
    }

    private void UpdateMoxxiUI() {
        moxieText.text = "Moxie: " + Moxie.ToString("F0");
        MoxieBar.fillAmount = Moxie / 100;


    }

    private void UpdateGritUI() {
        gritText.text = "Grit: " + Grit.ToString("F0");
        GritBar.fillAmount = Grit / 100;

    }

    private void UpdateHealthUI() {
        healthText.text = "Health: " + Health;
        healthBar.fillAmount = Health / 100;

    }
}
