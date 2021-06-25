using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechettePistol : Gun
{
    public float moxieBurstShots;

    public override void AltFire() {
        bulletsShot = 0;
        if (clipAmmo <=0) {
            PlayerStats.Instance.Moxie += moxieRequirement;
            return;
        }
        PlayerStats.Instance.Moxie -= moxieRequirement;
        animator.SetTrigger("isAltFire");
        MoxieBurst();
    }

    private void MoxieBurst() {
        readyToShoot = false;

        AimAndFireProjectile(primaryAmmo);
        if (allowInvoke) {
            Invoke("ResetShot", 1 / fireRate);
            allowInvoke = false;
        }

        if (bulletsShot < moxieBurstShots && clipAmmo > 0) {
            Invoke("MoxieBurst", 1 / (fireRate * moxieBurstShots));
        }

    }
}
