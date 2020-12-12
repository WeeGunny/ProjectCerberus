using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : Item
{

    public override void OnPickup() {
        float hp = PlayerManager.stats.HealthPacks;
        if (hp < PlayerManager.stats.HealthPackMax) {
            hp += 1;
            Destroy(gameObject);
        }
        else {
            Debug.Log("HealthPacks full");
        }
    }
}
