﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {
    [Header("Player Stats")]
    public float maxHeath;
    public float moxieMax = 100;
    public float gritMax = 100;
    public float moxieBatteyMax;
    public float HealthPackMax;

    [HideInInspector] public float Health = 100;
    [HideInInspector] public float Moxie = 100;
    [HideInInspector] public float Grit = 100;
    [HideInInspector] public float gold = 100;
    [HideInInspector] public float moxieBatteries;
    [HideInInspector] public float HealthPacks;



    [Header("UI Reference")]
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI healthText;
    public Image healthBar;
    public TextMeshProUGUI moxieText;
    public Image MoxieBar;
    public TextMeshProUGUI gritText;
    public Image GritBar;
    public TextMeshProUGUI ammoText;
    public Image ammoBar;
    public TextMeshProUGUI healthPackText;
    public Image healthPackBar;
    public TextMeshProUGUI moxieBatteryText;
    public Image moxieBatteryBar;

    [HideInInspector] public bool GritActive = false;
    [HideInInspector] public Gun activeGun;

    private void Start() {
        PlayerManager.instance.stats = this;
    }

    // Update is called once per frame
    void Update() {
        Moxie += Time.deltaTime;
        Moxie = Mathf.Clamp(Moxie, 0, moxieMax);
        UpdateMoxxiUI();


        if (GritActive == false) {
            Grit += Time.deltaTime;
            Grit = Mathf.Clamp(Grit, 0, gritMax);
            Time.timeScale = 1f;
        }
        UpdateGritUI();


        if (Grit <= 0) {
            GritActive = false;
        }

        UpdateAmmoUI();
        UpdateGoldUI();



    }

    private void UpdateGoldUI() {
        goldText.text = "Gold Amount: " + gold;
    }

    public void TakeDamage(float damage) {


        Mathf.Clamp(Health, 0, maxHeath);
        Health -= damage;
        UpdateHealthUI();

        if (Health <= 0) {
            Death();
        }
    }

    private void UpdateMoxxiUI() {
        moxieText.text = "Moxie: " + Moxie.ToString("F0");
        MoxieBar.fillAmount = Moxie / moxieMax;


    }

    private void UpdateGritUI() {
        gritText.text = "Grit: " + Grit.ToString("F0");
        GritBar.fillAmount = Grit / gritMax;

    }

    private void UpdateHealthUI() {
        healthText.text = "Health: " + Health;
        healthBar.fillAmount = Health / maxHeath;

    }

    private void UpdateAmmoUI() {
        if (activeGun != null) {
            string ammoClip = activeGun.clipAmmo.ToString();
            string ammoTotal = activeGun.currentAmmo.ToString();
            ammoText.text = ammoClip + "/" + ammoTotal;
            ammoBar.fillAmount = activeGun.clipAmmo / activeGun.maxClipAmmo;

        }
        else {
            ammoText.text = "0/0";
        }

        moxieBatteryText.text = moxieBatteries.ToString() + "/" + moxieBatteyMax.ToString();
        moxieBatteryBar.fillAmount = moxieBatteries / moxieBatteyMax;

        healthPackText.text = HealthPacks.ToString() + "/" + HealthPackMax.ToString();
        healthPackBar.fillAmount = HealthPacks / HealthPackMax;


    }

    private void Death() {
        Debug.Log("The player has died");
    }

}
