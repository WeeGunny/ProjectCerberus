using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualGun : Gun
{
    public override void Fire() {
        if (!AmmoCheck()) {
            return;
        }
        ShootProjectile();
    }
}
