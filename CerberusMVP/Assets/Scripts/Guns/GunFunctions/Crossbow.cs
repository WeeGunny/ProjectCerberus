using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossbow : Gun
{
    public override void AltFire() {
        base.AltFire();
        readyToShoot = false;
        AudioManager.audioManager.Play(AltFireSoundName, gameObject);
        Ray ray = fpsCam.ViewportPointToRay(new Vector3(.5f, .5f, 0)); // goes to center of screen;
        RaycastHit hit;
        Vector3 targetPoint;
        GetComponent<SimpleRecoil>().AddRecoil();
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

        GameObject bullet = Instantiate(altAmmo, firePoint.position, Quaternion.identity);
        bullet.transform.forward = directionWithSpread;
        bullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * bulletSpeed, ForceMode.Impulse);
        clipAmmo--;

        if (allowInvoke) {
            Invoke("ResetShot", 1 / fireRate);
            allowInvoke = false;
        }
    }
}
