using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : Item
{

    public override void OnPickup() {
        if (PlayerStats.HealthPacks < PlayerManager.stats.HealthPackMax) {
            PlayerStats.HealthPacks += 1;
            Destroy(gameObject);
        }
        else {
            Debug.Log("HealthPacks full");
        }
    }
}
