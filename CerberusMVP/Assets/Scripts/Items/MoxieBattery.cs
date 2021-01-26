using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoxieBattery : Item
{
    private void Start() {
        LeanTween.rotateAround(this.gameObject, Vector3.up, 360, 3).setLoopClamp();
    }

    public override void OnPickup() {
        if (PlayerStats.moxieBatteries< PlayerManager.stats.moxieBatteyMax) {
            PlayerStats.moxieBatteries += 1;
            Debug.Log("Picked up Moxie Battery, you have: " + PlayerStats.moxieBatteries);
            Destroy(gameObject);
        }
        else {
            Debug.Log("MoxieBatteries full");
        }
    }

    public override void OnBuy() {
        if (PlayerStats.moxieBatteries < PlayerManager.stats.moxieBatteyMax) {
            PlayerStats.moxieBatteries += 1;
        }
        else {
            PlayerStats.gold += cost;
            Debug.Log("MoxieBatteries full");
        }
    }
}
