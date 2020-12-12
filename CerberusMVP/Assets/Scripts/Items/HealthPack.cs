using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : Item
{

    public override void OnPickup() {
        float hp = PlayerManager.instance.stats.HealthPacks;
        if (hp < PlayerManager.instance.stats.HealthPackMax) {
            hp += 1;
            Destroy(gameObject);
        }
        else {
            Debug.Log("HealthPacks full");
        }
    }
}
