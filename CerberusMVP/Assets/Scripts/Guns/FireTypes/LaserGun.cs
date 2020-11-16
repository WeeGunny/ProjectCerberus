using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : Gun {
    GameObject laser;
    public bool firingLaser = false;

    protected override void Update() {
        base.Update();
        if (laser != null && !firingLaser) {
            Debug.Log("laser Destroyed");
            Destroy(laser);
        }
    }
    public override void Fire() {
        if (!AmmoCheck()) {
            return;
        }
        Debug.Log("Creating Laser");
        laser = Instantiate(primaryAmmo, firePoint);
        firingLaser = true;
    }

    public override void OnFireHeld() {
        if (!AmmoCheck() || !firingLaser) {
            return;
        }
        LineRenderer beam = laser.GetComponentInChildren<LineRenderer>();
        RaycastHit hit;
        if (Physics.Raycast(firePoint.position, firePoint.forward, out hit, range)) {
            beam.SetPosition(1, new Vector3(0, 0, hit.point.z));
            EnemyController enemy = hit.collider.GetComponent<EnemyController>();
            if (enemy != null) {
                enemy.TakeDamage(Dmg, damageType);
                DmgPopUp.Create(hit.point, Dmg);
            }
            SpiderController spider = hit.collider.GetComponent<SpiderController>();
            if (spider != null) {
                spider.TakeDamage(Dmg,damageType);
            }
        }
        else {
            beam.SetPosition(1, new Vector3(0, 0, range));
        }
        ammoInClip--;
        if (ammoInClip == 0) {
            firingLaser = false;
            Destroy(laser);

        }
        lastTimeFired = Time.time;
    }

    public override void EndFire() {
        firingLaser = false;
        Destroy(laser);
    }

}
