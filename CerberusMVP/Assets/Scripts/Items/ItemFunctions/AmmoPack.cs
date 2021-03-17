using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPack : ItemFunction
{
    public float MaxAmmo, MinAmmo;
    float ammoAmount;

    private void Start() {
        ammoAmount = Random.Range(MinAmmo,MaxAmmo);
    }
    public override bool TryPickup() {
        float ammo = PlayerManager.stats.activeGun.currentAmmo;
        if (ammo < PlayerManager.stats.activeGun.maxAmmo) {
            ammo += ammoAmount;
            return true;
        }
        else {
            return false;
            Debug.Log("Ammo full");
        }
    }

    public override bool TryBuy() {
        float ammo = PlayerManager.stats.activeGun.currentAmmo;
        if (ammo < PlayerManager.stats.activeGun.maxAmmo) {
            ammo += ammoAmount;
            return true;
        }
        else {
            return false;
            Debug.Log("Ammo full");
        }
    }

}
