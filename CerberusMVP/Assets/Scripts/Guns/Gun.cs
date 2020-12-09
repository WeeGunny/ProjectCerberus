﻿
using System.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Gun : MonoBehaviour {
    public GameObject gunPrefab;
    public Animator animator;
    public Transform firePoint;
    public GameObject primaryAmmo, altAmmo;
    protected Camera fpsCam;
    public float Dmg = 10f, altDmg = 10f;
    public float bulletSpeed = 25f, altSpeed = 25f;
    protected float bulletsShot;
    public float spread;

    public float moxieRequirement = 20;
    public float maxAmmo, maxClipAmmo;
    public float clipAmmo, currentAmmo;
    //FireRate is shots per second
    public float fireRate = 1, bulletsPerShot = 1, reloadTime;
    public bool shooting, readyToShoot, reloading;
    public bool allowHold;
    public string soundName;
    protected bool allowInvoke = true;

    //Recoil
    public Rigidbody playerRb;
    public float recoilForce;


    protected void Awake() {
        currentAmmo = maxAmmo;
        readyToShoot = true;
        fpsCam = FindObjectOfType<GunManager>().fpsCam;
        Debug.Log("Loaded Gun");
        Reload();
    }

    private void Update() {
        GunInput();
    }

    protected virtual void GunInput() {
        if (allowHold) {
            shooting = Input.GetKey(KeyCode.Mouse0);
        }
        else {
            shooting = Input.GetKeyDown(KeyCode.Mouse0);
        }

        if (readyToShoot && shooting && !reloading && clipAmmo>0) {
            bulletsShot = 0;
            Debug.Log("Firing");
            Fire();
        }

        if (Input.GetKeyDown(KeyCode.Mouse1) && PlayerManager.instance.stats.Moxie> moxieRequirement) AltFire();

        if (Input.GetKeyDown(KeyCode.R) && clipAmmo < maxClipAmmo && !reloading) Reload();

        if (readyToShoot && shooting && !reloading && clipAmmo <= 0) Reload(); // auto reload if out of ammo

    }

    public virtual void Fire() {
        readyToShoot = false;
        FindObjectOfType<AudioManager>().Play(soundName);
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
        Vector3 directionWithSpread = directionNoSpread + new Vector3(spreadX/10, spreadY/10, 0);

        GameObject bullet = Instantiate(primaryAmmo, firePoint.position, Quaternion.identity);
        bullet.transform.forward = directionWithSpread;
        bullet.GetComponent<PlayerProjectile>().damage = Dmg;
        bullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * bulletSpeed, ForceMode.Impulse);
        clipAmmo--;
        bulletsShot++;

        //player recoil
        playerRb.AddForce(-directionWithSpread.normalized * recoilForce, ForceMode.Impulse);

        if (allowInvoke) {
            Invoke("ResetShot", 1 / fireRate);
            allowInvoke = false;
        }

        if (bulletsShot < bulletsPerShot && clipAmmo > 0) {
            Invoke("ShootProjectile", 1 / (fireRate*bulletsPerShot));
        }
    }

    protected void ResetShot() {
        Debug.Log("ResetShot");
        animator.SetBool("isShooting", false);
        readyToShoot = true;
        allowInvoke = true;
    }

    public virtual void AltFire() {
        PlayerManager.instance.stats.Moxie -= moxieRequirement;
        //FindObjectOfType<AudioManager>().Play("AltFire");
        animator.SetTrigger("altFire");
    }

    public void ReloadDelay() {
        reloading = true;
        Invoke("Reload", reloadTime);
    }

    public void Reload() {
        Debug.Log("Reloading");
        animator.SetTrigger("isReloading");
        FindObjectOfType<AudioManager>().Play("Reload");
        float reloadAmount = maxClipAmmo - clipAmmo;
        if (currentAmmo >= reloadAmount) {
            clipAmmo += reloadAmount;
            currentAmmo -= reloadAmount;
        }
        else {
            clipAmmo += currentAmmo;
            currentAmmo = 0;
        }
        reloading = false;
    }
}
