using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstGun : Gun
{
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
                yield return new WaitForSeconds(.1f);
            }
        }
    }
}
