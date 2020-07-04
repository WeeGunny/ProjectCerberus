using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstGun : Gun
{
    public float burstFireRounds;
    public override void Fire() {
        if (!AmmoCheck()) {
            return;
        }
        StartCoroutine("BurstFire");
    }

    public IEnumerator BurstFire() {

        Debug.Log("Starting Burst fire");
        for (int b = 0; b < 3; b++) {
            if (ammoInClip > 0) {
                ShootProjectile();
               yield return new WaitForSecondsRealtime(0.1f);
            }
            Debug.Log("are you still going?");
        }
        yield return null;
    }
}
