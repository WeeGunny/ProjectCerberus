
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class PlayerStatsUI : MonoBehaviour {
    private PlayerStats stats =>PlayerStats.Instance;

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

    private void Awake() {
        

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
        goldText.text = "x" + stats.gold;
    }


    private void UpdateMoxie() {
        stats.Moxie += Time.deltaTime;
        stats.Moxie = Mathf.Clamp(stats.Moxie, 0, stats.moxieMax);
        moxieText.text = stats.Moxie.ToString("F0");
        MoxieBar.fillAmount = stats.Moxie / stats.moxieMax;
    }

    private void UpdateGrit() {

        if (stats.GritActive) {
            stats.Grit -= Time.deltaTime * (10 / Time.timeScale);
            Debug.Log(stats.Grit);
        }
        if (!stats.GritActive) {
            stats.Grit += Time.deltaTime;
            stats.Grit = Mathf.Clamp(stats.Grit, 0, stats.gritMax);
        }
        if (stats.Grit <= 0) {
            stats.GritActive = false;
            Time.timeScale = 1f;
        }
        gritText.text = stats.Grit.ToString("F0");
        GritBar.fillAmount = stats.Grit / stats.gritMax;
    }

    private void UpdateHealthUI() {
        healthText.text = stats.Health.ToString();
        healthBar.fillAmount = stats.Health / stats.maxHeath;

    }

    private void UpdateAmmoUI() {
        string ammoClip = GunManager.instance.currentGun.clipAmmo.ToString();
        string ammoTotal = GunManager.instance.currentGun.currentAmmo.ToString();
        ammoText.text = ammoClip;
        totalAmmoText.text = ammoTotal;


        moxieBatteryText.text = stats.moxieBatteries.ToString();

        healthPackText.text = stats.HealthPacks.ToString();
    }



    private void OnApplicationQuit() {
        stats.ResetValues();
    }


}
