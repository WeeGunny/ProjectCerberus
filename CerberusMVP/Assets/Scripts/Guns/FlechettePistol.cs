using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechettePistol : ManualGun
{
    public float burstFireRounds;
    public override void AltFire() {
        if (!AmmoCheck()) {
            return;
        }
        StartCoroutine("BurstFire");

    }

    public IEnumerator BurstFire() {

        Debug.Log("Starting Burst fire");
       for (int b = 0; b < burstFireRounds; b++) {
            if (ammoInClip > 0) {
                ShootProjectile();
                Debug.Log("Shot a bullet");

                yield return new WaitForSeconds(.1f);
            }
        }
    }
}
