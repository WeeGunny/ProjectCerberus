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

    //public for access but not needed in inspector
    public static float Health;
    public static float Moxie;
    public static float Grit;
    public static float gold;
    public static float moxieBatteries;
    public static float HealthPacks;



    [Header("UI Reference")]
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI healthText;
    public Image healthBar;
    public TextMeshProUGUI moxieText;
    public Image MoxieBar;
    public TextMeshProUGUI gritText;
    public Image GritBar;
    public TextMeshProUGUI ammoText, totalAmmoText;
    public TextMeshProUGUI healthPackText;
    public TextMeshProUGUI moxieBatteryText;

    public static bool GritActive = false;
    [HideInInspector] public Gun activeGun;

    private void Awake() {
        if (PlayerManager.stats == null) {
            PlayerManager.stats = this;
            SetUpStats();
        }

    }

    private void Start() {

    }

    private void SetUpStats() {
        Health = maxHeath;
        UpdateHealthUI();
        Moxie = moxieMax;
        Grit = gritMax;
    }
    // Update is called once per frame
    void Update() {
        UpdateMoxie();
        UpdateGrit();
        UpdateHealthUI();
        UpdateAmmoUI();
        UpdateGoldUI();
    }

    private void UpdateGoldUI() {
        goldText.text = "Gold Amount: " + gold;
    }

    public void TakeDamage(float damage) {
        Health -= damage;
        Mathf.Clamp(Health, 0, maxHeath);
        UpdateHealthUI();

        if (Health <= 0) {
            Death();
        }
        FindObjectOfType<AudioManager>().Play("Player Damaged", gameObject);
    }

    private void UpdateMoxie() {
        Moxie += Time.deltaTime;
        Moxie = Mathf.Clamp(Moxie, 0, moxieMax);
        moxieText.text = Moxie.ToString("F0");
        MoxieBar.fillAmount = Moxie / moxieMax;
    }

    private void UpdateGrit() {

        if (GritActive) {
            PlayerStats.Grit -= Time.deltaTime * (10 / Time.timeScale);
        }
        if (!GritActive) {
            Grit += Time.deltaTime;
            Grit = Mathf.Clamp(Grit, 0, gritMax);
        }
        if (Grit <= 0) {
            PlayerStats.GritActive = false;
            Time.timeScale = 1f;
        }
        gritText.text = Grit.ToString("F0");
        GritBar.fillAmount = Grit / gritMax;
    }

    private void UpdateHealthUI() {
        healthText.text = Health.ToString();
        healthBar.fillAmount = Health / maxHeath;
    }

    private void UpdateAmmoUI() {
        if (activeGun != null) {
            string ammoClip = activeGun.clipAmmo.ToString();
            string ammoTotal = activeGun.currentAmmo.ToString();
            ammoText.text = ammoClip;
            totalAmmoText.text = ammoTotal;
        }
        else {
            ammoText.text = "0";
        }

        moxieBatteryText.text = moxieBatteries.ToString();

        healthPackText.text = HealthPacks.ToString();
    }

    private void Death() {
        rbPlayer.isDead = true;
    }

}
