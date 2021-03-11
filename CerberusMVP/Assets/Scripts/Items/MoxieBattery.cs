using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoxieBattery : ItemFunction
{


    public override bool TryPickup() {
        if (PlayerStats.moxieBatteries< PlayerManager.stats.moxieBatteyMax) {
            PlayerStats.moxieBatteries += 1;
            Debug.Log("Picked up Moxie Battery, you have: " + PlayerStats.moxieBatteries);
            return true;
        }
        else {
            return false;
            Debug.Log("MoxieBatteries full");
        }
    }

    public override bool TryBuy() {
        if (PlayerStats.moxieBatteries < PlayerManager.stats.moxieBatteyMax) {
            PlayerStats.moxieBatteries += 1;
            return true;
        }
        else {
            return false;
            Debug.Log("MoxieBatteries full");
        }
    }
}
