using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : Gun {
    GameObject laser;
    public Transform CoreBoneTransform;
    public bool firingLaser = false;
    public float laserRange;
    public DamageType damageType;
    LineRenderer beam;

    private void Update() {
        GunInput();
        if (firingLaser) {
            UpdateLaser();
        }
        //Changes the size of black hole core depending on moxie left 
        CoreBoneTransform.localScale = new Vector3(0.01f, 0.01f, 0.01f) * PlayerManager.instance.stats.Moxie;
        if (PlayerManager.instance.stats.Moxie < moxieRequirement) {
            CoreBoneTransform.localScale = new Vector3(0f, 0f, 0f);
        }
    }

    protected override void GunInput() {
        if (allowHold) {
            shooting = Input.GetKey(KeyCode.Mouse0);
        }
        if (readyToShoot && shooting && !reloading && clipAmmo > 0 ) {
            Fire();
        }
        if (firingLaser && Input.GetKeyUp(KeyCode.Mouse0)) {
            StopLaser();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && PlayerManager.instance.stats.Moxie > moxieRequirement) AltFire();

        if (Input.GetKeyDown(KeyCode.R) && clipAmmo < maxClipAmmo && !reloading) Reload();
    }
    public override void Fire() {
        readyToShoot = false;
        if(firingLaser== false) {
            Debug.Log("Creating Laser");
            laser = Instantiate(primaryAmmo);
            beam = laser.GetComponent<LineRenderer>();
            firingLaser = true;
        }
        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, laserRange)) {
            EnemyController enemy = hit.collider.GetComponent<EnemyController>();
            if (enemy != null) {
                enemy.TakeDamage(Dmg, damageType);
            }
            SpiderController spider = hit.collider.GetComponent<SpiderController>();
            if (spider != null) {
                spider.TakeDamage(Dmg, damageType);
            }
        }
        clipAmmo--;
        beam.SetPosition(0, firePoint.position);
        if (allowInvoke) {
            Invoke("ResetShot", 1 / fireRate); // fire resets how often damage is taken and ammo is consumed
            allowInvoke = false;
        }
    }

    public override void AltFire() {
        base.AltFire();
        readyToShoot = false;
        GameObject altBullet = Instantiate(altAmmo, firePoint.position, Quaternion.identity);
        altBullet.GetComponent<Rigidbody>().AddForce(firePoint.forward*altSpeed,ForceMode.Impulse);
    }

    public void UpdateLaser() {
        beam.SetPosition(0,firePoint.position);
        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, laserRange)) {
            beam.SetPosition(1, hit.point);
        }
        else {
            beam.SetPosition(1, ray.GetPoint(laserRange));
        }
        if (clipAmmo == 0) {
            firingLaser = false;
            StopLaser();
            Destroy(laser);
        }
    }
    public void StopLaser() {
        firingLaser = false;
        shooting = false;
        Destroy(laser);
        if (allowInvoke) {
            Invoke("ResetShot", 1 / fireRate);
            allowInvoke = false;
        }
    }

}
