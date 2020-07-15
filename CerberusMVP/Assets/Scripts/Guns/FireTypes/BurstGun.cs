using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstGun : Gun {

    public float burstFireRounds;
    public override void Fire() {
        if (!AmmoCheck()) {
            return;
        }
        StartCoroutine(BurstFire());


    }

    public override IEnumerator BurstFire() {
        base.BurstFire();

        for (int b = 0; b < 3; b++) {
            Debug.Log("Burst fire");
            if (ammoInClip > 0) {
                ShootProjectile();
                yield return new WaitForSecondsRealtime(0.1f);
            }

        }


    }

}
