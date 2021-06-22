using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoxieBattery : ItemFunction
{


    public override bool TryPickup() {
        if (PlayerStats.Instance.moxieBatteries< PlayerStats.Instance.moxieBatteyMax) {
            AudioManager.audioManager.Play("Item Pickup", rbPlayer.Player.gameObject);
            PlayerStats.Instance.moxieBatteries += 1;
            Debug.Log("Picked up Moxie Battery, you have: " + PlayerStats.Instance.moxieBatteries);
            return true;
        }
        else {
            return false;
        }
    }

    public override bool TryBuy() {
        if (PlayerStats.Instance.moxieBatteries < PlayerStats.Instance.moxieBatteyMax) {
            PlayerStats.Instance.moxieBatteries += 1;
            return true;
        }
        else {
            return false;
        }
    }
}
