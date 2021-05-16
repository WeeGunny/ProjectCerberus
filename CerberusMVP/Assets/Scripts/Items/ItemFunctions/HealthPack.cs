using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : ItemFunction
{
    public override bool TryPickup() {
        if (PlayerManager.stats.HealthPacks < PlayerManager.stats.HealthPackMax) {
            AudioManager.audioManager.Play("Item Pickup", PlayerManager.player);
            PlayerManager.stats.HealthPacks += 1;
            return true;
        }
        else {
            return false;
            Debug.Log("HealthPacks full");
        }
    }

    public override bool TryBuy() {
        if (PlayerManager.stats.HealthPacks < PlayerManager.stats.HealthPackMax) {
            PlayerManager.stats.HealthPacks += 1;
            return true;
        }
        else {
            return false;
            Debug.Log("HealthPacks full");
        }
    }
}
