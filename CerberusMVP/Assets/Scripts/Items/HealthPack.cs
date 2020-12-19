using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : Item
{
    private void Start() {
        LeanTween.rotateAround(this.gameObject, Vector3.up, 360, 3).setLoopClamp();
    }
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
