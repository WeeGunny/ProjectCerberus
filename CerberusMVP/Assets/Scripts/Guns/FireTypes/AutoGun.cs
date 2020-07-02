using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoGun : Gun
{
    public override void Fire() {
        if (!AmmoCheck()) {
            return;
        }
    }

    public override void OnFireHeld() {
        if (!AmmoCheck()) {
            return;
        }
        ShootProjectile();
        
    }

}
