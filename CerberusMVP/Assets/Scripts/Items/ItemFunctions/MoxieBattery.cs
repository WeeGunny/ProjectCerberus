using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoxieBattery : ItemFunction
{


    public override bool TryPickup() {
        if (PlayerManager.stats.moxieBatteries< PlayerManager.stats.moxieBatteyMax) {
            AudioManager.audioManager.Play("Item Pickup", PlayerManager.player);
            PlayerManager.stats.moxieBatteries += 1;
            Debug.Log("Picked up Moxie Battery, you have: " + PlayerManager.stats.moxieBatteries);
            return true;
        }
        else {
            return false;
            Debug.Log("MoxieBatteries full");
        }
    }

    public override bool TryBuy() {
        if (PlayerManager.stats.moxieBatteries < PlayerManager.stats.moxieBatteyMax) {
            PlayerManager.stats.moxieBatteries += 1;
            return true;
        }
        else {
            return false;
            Debug.Log("MoxieBatteries full");
        }
    }
}
