using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPack : Item
{
    public float MaxAmmo, MinAmmo;
    float ammoAmount;

    private void Start() {
        ammoAmount = Random.Range(MinAmmo,MaxAmmo);
    }
    public override void OnPickup() {
        float ammo = PlayerManager.stats.activeGun.currentAmmo;
        if (ammo < PlayerManager.stats.activeGun.maxAmmo) {
            ammo += ammoAmount;
            Destroy(gameObject);
        }
        else {
            Debug.Log("Ammo full");
        }
    }

    public override void OnBuy() {
        float ammo = PlayerManager.stats.activeGun.currentAmmo;
        if (ammo < PlayerManager.stats.activeGun.maxAmmo) {
            ammo += ammoAmount;
        }
        else {
            PlayerStats.gold += cost;
            Debug.Log("Ammo full");
        }

    }

}
