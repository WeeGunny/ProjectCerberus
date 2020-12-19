using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoxieBattery : Item
{
    private void Start() {
        LeanTween.rotateAround(this.gameObject, Vector3.up, 360, 3).setLoopClamp();
    }

    public override void OnPickup() {
        float mb = PlayerStats.moxieBatteries;
        if (mb< PlayerManager.stats.moxieBatteyMax) {
            mb += 1;
            Debug.Log("Picked up Moxie Battery, you have: " + mb);
            Destroy(gameObject);
        }
        else {
            Debug.Log("MoxieBatteries full");
        }
    }
}
