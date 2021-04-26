using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechettePistol : Gun
{
    public float moxieBurstShots;

    public override void AltFire() {
        bulletsShot = 0;
        if (clipAmmo <=0) {
            PlayerManager.stats.Moxie += moxieRequirement;
            return;
        }
        PlayerManager.stats.Moxie -= moxieRequirement;
        animator.SetTrigger("isAltFire");
        MoxieBurst();
    }

    private void MoxieBurst() {
        readyToShoot = false;

        Ray ray = fpsCam.ViewportPointToRay(new Vector3(.5f, .5f, 0)); // goes to center of screen;
        RaycastHit hit;
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit)) {
            targetPoint = hit.point;
        }
        else {
            targetPoint = ray.GetPoint(75);
        }

        Vector3 directionNoSpread = targetPoint - firePoint.position;

        float spreadX = Random.Range(-spread, spread);
        float spreadY = Random.Range(-spread, spread);
        Vector3 directionWithSpread = directionNoSpread + new Vector3(spreadX / 10, spreadY / 10, 0);

        GameObject bullet = Instantiate(primaryAmmo, firePoint.position, Quaternion.identity);
        bullet.transform.forward = directionWithSpread;
        bullet.GetComponent<PlayerProjectile>().damage = Dmg;
        bullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * bulletSpeed, ForceMode.Impulse);
        AudioManager.audioManager.Play(AltFireName, gameObject);
        clipAmmo--;
        bulletsShot++;

        if (allowInvoke) {
            Invoke("ResetShot", 1 / fireRate);
            allowInvoke = false;
        }

        if (bulletsShot < moxieBurstShots && clipAmmo > 0) {
            Invoke("MoxieBurst", 1 / (fireRate * moxieBurstShots));
        }

    }
}
