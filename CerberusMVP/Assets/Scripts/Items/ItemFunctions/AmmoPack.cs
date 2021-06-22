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
        float ammo = GunManager.instance.currentGun.clipAmmo;
        if (ammo < GunManager.instance.currentGun.maxAmmo) {
            ammo += ammoAmount;
            return true;
        }
        else {
            return false;
        }
    }

    public override bool TryBuy() {
        float ammo = GunManager.instance.currentGun.currentAmmo;
        if (ammo < GunManager.instance.currentGun.maxAmmo) {
            ammo += ammoAmount;
            return true;
        }
        else {
            return false;
        }
    }

}
