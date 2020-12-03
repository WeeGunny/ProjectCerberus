using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : Gun {
    GameObject laser;
    public bool firingLaser = false;
    public float laserRange;
    public DamageType damageType;
    LineRenderer beam;

    private void Update() {
        GunInput();
        if (firingLaser) {
            UpdateLaser();
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

        if (Input.GetKeyDown(KeyCode.R) && clipAmmo < maxClipAmmo && !reloading) Reload();

        if (readyToShoot && shooting && !reloading && clipAmmo <= 0) Reload();
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
            Invoke("ResetShot", 1 / fireRate);
            allowInvoke = false;
        }



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

    public void LaserDamage() {
        readyToShoot = false;
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
