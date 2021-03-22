using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : ItemFunction
{
    public override bool TryPickup() {
        if (PlayerStats.HealthPacks < PlayerManager.stats.HealthPackMax) {
            PlayerStats.HealthPacks += 1;
            FindObjectOfType<AudioManager>().Play("Item Pickup", gameObject);
            return true;
        }
        else {
            return false;
            Debug.Log("HealthPacks full");
        }
    }

    public override bool TryBuy() {
        if (PlayerStats.HealthPacks < PlayerManager.stats.HealthPackMax) {
            PlayerStats.HealthPacks += 1;
            return true;
        }
        else {
            return false;
            Debug.Log("HealthPacks full");
        }
    }
}
