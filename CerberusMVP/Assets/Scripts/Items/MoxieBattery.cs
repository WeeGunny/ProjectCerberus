using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoxieBattery : Item
{

    public override void OnPickup() {
        float mb = PlayerManager.stats.moxieBatteries;
        if (mb< PlayerManager.stats.moxieBatteyMax) {
            mb += 1;
            Destroy(gameObject);
        }
        else {
            Debug.Log("MoxieBatteries full");
        }
    }
}
