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
        float ammo = PlayerManager.instance.stats.activeGun.currentAmmo;
        if (ammo < PlayerManager.instance.stats.activeGun.maxAmmo) {
            ammo += ammoAmount;
            Destroy(gameObject);
        }
        else {
            Debug.Log("Ammo full");
        }
    }

}
