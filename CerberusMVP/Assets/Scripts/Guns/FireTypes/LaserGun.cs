using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : Gun {
    GameObject laser;
    public bool firingLaser = false;
    public float laserRange;
    public DamageType damageType;
    LineRenderer beam;
    
    private void Awake() {
    }

    private void Update() {
        GunInput();
        if (laser != null && !firingLaser) {
            Debug.Log("laser Destroyed");
            Destroy(laser);
        }
    }

    protected override void GunInput() {
        if (allowHold) {
            shooting = Input.GetKey(KeyCode.Mouse0);
        }
        else {
            shooting = Input.GetKeyDown(KeyCode.Mouse0);
        }

        if (readyToShoot && shooting && !reloading && clipAmmo > 0) {
            Debug.Log("Firing");
            Fire();
        }
        if (shooting && Input.GetKeyUp(KeyCode.Mouse0)) {

        }

        if (Input.GetKeyDown(KeyCode.R) && clipAmmo < maxClipAmmo && !reloading) Reload();

        if (readyToShoot && shooting && !reloading && clipAmmo <= 0) Reload();
    }
    public override void Fire() {
        Debug.Log("Creating Laser");
        laser = Instantiate(primaryAmmo, firePoint);
        firingLaser = true;
        beam.SetPosition(0, firePoint.position);

    }

    public void UpdateLaser() {
        beam.SetPosition(0,firePoint.position);
        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, laserRange)) {
            beam.SetPosition(1, hit.point);
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
            beam.SetPosition(1, ray.GetPoint(laserRange));
        }
        clipAmmo--;
        if (clipAmmo == 0) {
            firingLaser = false;
            Destroy(laser);

        }
    }

    public void StopLaser() {
        firingLaser = false;
        Destroy(laser);
    }

}
