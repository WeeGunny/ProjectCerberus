
using System.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Rendering.PostProcessing;

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

    //Grit Effect
    public PostProcessVolume ppv;

    //[Header("Recoil")]
    //public Vector3 upRecoil;
    //Vector3 orignalRotation;
    //public float minRecoil = -1;
    //public float maxRecoil = -10;

    protected void Awake() {
        currentAmmo = maxAmmo;
        readyToShoot = true;
        fpsCam = FindObjectOfType<GunManager>().fpsCam;
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
            Fire();
        }

        if (Input.GetKeyDown(KeyCode.Mouse1) && PlayerStats.Moxie> moxieRequirement) AltFire();

        if (Input.GetKeyDown(KeyCode.R) && clipAmmo < maxClipAmmo && !reloading) ReloadDelay();

        if (readyToShoot && shooting && !reloading && clipAmmo <= 0) ReloadDelay(); // auto reload if out of ammo

    }

    public virtual void Fire() {
        readyToShoot = false;
        //FindObjectOfType<AudioManager>().Play(soundName);
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
        PlayerStats.Moxie -= moxieRequirement;
        animator.SetTrigger("altFire");
    }

    public void ReloadDelay() {
        reloading = true;
        Invoke("Reload", reloadTime);
    }

    public void Reload() {
        Debug.Log("Reloading");
        animator.SetTrigger("isReloading");
        //FindObjectOfType<AudioManager>().Play("Reload");
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
