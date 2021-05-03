using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats")]
public class StatsSO : ScriptableObject {
    [Header("Default Player Stats")]
    public float maxHeath;
    public float moxieMax = 100;
    public float gritMax = 100;
    public float moxieBatteyMax;
    public float HealthPackMax;
    public GunInfo StartingPrimary, StartingSecondary;

    [Header("Player Stats")]
    public float Health;
    public float Moxie;
    public float Grit;
    public float gold;
    public float moxieBatteries;
    public float HealthPacks;

    public GunInfo PrimaryGun, SecondaryGun, CurrentGun;

    public bool isSetUp = false, PrimaryGunActive = true;
    public bool GritActive = false;

    public void TakeDamage(float damage) {
        Health -= damage;
        Mathf.Clamp(Health, 0, maxHeath);
        FindObjectOfType<AudioManager>().Play("Player Hurt", PlayerManager.player);
        if (Health <= 0) {
            Death();
        }
    }

    private void Death() {
        ResetValues();
        rbPlayer.isDead = true;       
    }
    public void SetUpStats() {
        Health = maxHeath;
        Moxie = moxieMax;
        Grit = gritMax;
        HealthPacks = 1;
        moxieBatteries = 1;
        isSetUp = true;
        PrimaryGun = StartingPrimary;
        SecondaryGun = StartingSecondary;
        CurrentGun = PrimaryGun;
    }

    public void ResetValues() {
        isSetUp = false;
        PrimaryGunActive = true;
        Health = 0;
        Moxie = 0;
        Grit = 0;
        gold = 0;
        moxieBatteries = 0;
        HealthPacks = 0;
        PrimaryGun = null;
        SecondaryGun = null;
        CurrentGun = null;
    }

    public void SaveGuns(GunInfo GMPrimary, GunInfo GMSecondary, GunInfo GMCurrent) {
        PrimaryGun = GMPrimary;
        SecondaryGun = GMSecondary;
        CurrentGun = GMCurrent;
    }
}
