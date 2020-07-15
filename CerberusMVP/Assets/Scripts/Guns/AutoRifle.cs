using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRifle : AutoGun
{
    public override void AltFire() {
        Vector3 direction = firePoint.forward;
        GameObject bullet = Instantiate(altAmmo, firePoint.position, Quaternion.identity);
        PlayerProjectile bulletProperties = bullet.GetComponent<PlayerProjectile>();
        bulletProperties.SetAltStats(this);
        bulletProperties.damage = PlayerManager.instance.stats.Moxie * 2;
        PlayerManager.instance.stats.Moxie =0;

    }


}
