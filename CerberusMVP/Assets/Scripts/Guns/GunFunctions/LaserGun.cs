using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LaserGun : Gun {
    GameObject laser;
    public Transform CoreBoneTransform;
    public bool firingLaser = false;
    public float laserRange;
    public DamageType damageType;
    LineRenderer beam;

    private void Update() {
        if (fireHeld && firingLaser) {
            UpdateLaser();
        }
        else if (!fireHeld && firingLaser) {
            StopLaser();
        }
        //Changes the size of black hole core depending on moxie left 
        CoreBoneTransform.localScale = new Vector3(0.01f, 0.01f, 0.01f) * PlayerManager.stats.Moxie;
        if (PlayerManager.stats.Moxie < moxieRequirement) {
            CoreBoneTransform.localScale = new Vector3(0f, 0f, 0f);
        }
    }

    public override void OnPrimaryFire() {

        if (readyToShoot && !reloading && GunManager.canFire) {
            if (clipAmmo > 0) Fire();
            else ReloadDelay();
        }
    }
    public override void Fire() {
        if (firingLaser == false ) {
            Debug.Log("Creating Laser");
            laser = Instantiate(primaryAmmo);
            beam = laser.GetComponent<LineRenderer>();
            firingLaser = true;
            FindObjectOfType<AudioManager>().Play(fireSoundName, gameObject);
            beam.SetPosition(0, firePoint.position);
        }    
    }

    public override void AltFire() {
        base.AltFire();
        readyToShoot = false;
        StopLaser();
        GameObject altBullet = Instantiate(altAmmo, firePoint.position, Quaternion.identity);
        altBullet.GetComponent<Rigidbody>().AddForce(firePoint.forward * altSpeed, ForceMode.Impulse);
    }

    public void UpdateLaser() {
        beam.SetPosition(0, firePoint.position);
        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, laserRange)) {
            beam.SetPosition(1, hit.point);
        }
        else {
            beam.SetPosition(1, ray.GetPoint(laserRange));
        }

        if (readyToShoot) BeamDamage();
        if (clipAmmo <= 0) {
            firingLaser = false;
            StopLaser();
            Destroy(laser);
            ReloadDelay();
        }
    }

    private void BeamDamage() {
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
        if (allowInvoke) {
            Invoke("ResetShot", 1 / fireRate); // fire resets how often damage is taken and ammo is consumed
            allowInvoke = false;
        }

    }
    public void StopLaser() {
        firingLaser = false;
        fireHeld = false;
        Destroy(laser);
        if (allowInvoke) {
            Invoke("ResetShot", 1 / fireRate);
            allowInvoke = false;
        }
        FindObjectOfType<AudioManager>().Stop(fireSoundName);
    }

    private void OnDisable() {
        StopLaser();
    }

}
