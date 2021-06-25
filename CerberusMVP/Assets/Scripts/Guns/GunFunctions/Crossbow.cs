using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossbow : Gun
{
    public override void AltFire() {
        base.AltFire();
        bulletsShot = 0;
        AimAndFireProjectile(altAmmo);

        if (allowInvoke) {
            Invoke("ResetShot", 1 / fireRate);
            allowInvoke = false;
        }
    }
}
