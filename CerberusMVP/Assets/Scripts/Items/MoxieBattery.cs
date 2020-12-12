using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoxieBattery : Item
{

    public override void OnPickup() {
        float mb = PlayerManager.instance.stats.moxieBatteries;
        if (mb< PlayerManager.instance.stats.moxieBatteyMax) {
            mb += 1;
            Destroy(gameObject);
        }
        else {
            Debug.Log("MoxieBatteries full");
        }
    }
}
