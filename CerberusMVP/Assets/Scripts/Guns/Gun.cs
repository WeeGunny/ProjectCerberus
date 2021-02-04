
using System.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour {
    public GameObject gunPrefab;
    public Animator animator;
    public Transform firePoint;
    public GameObject primaryAmmo, altAmmo;
    protected Camera fpsCam => FindObjectOfType<GunManager>().fpsCam;
    public float Dmg = 10f, altDmg = 10f;
    public float bulletSpeed = 25f, altSpeed = 25f;
    protected float bulletsShot;
    public float spread;

    public float moxieRequirement = 20;
    public float maxAmmo, maxClipAmmo;
    public float clipAmmo, currentAmmo;
    //FireRate is shots per second
    public float fireRate = 1, bulletsPerShot = 1, reloadTime;
    public bool fireHeld, readyToShoot, reloading;
    public bool allowHold;
    public string soundName;
    protected bool allowInvoke = true;

    //Grit Effect
    public PostProcessVolume ppv;

    protected PlayerControls controls;

    protected void Awake() {
        currentAmmo = maxAmmo;
        readyToShoot = true;
        controls = new PlayerControls();
        Reload();
    }

    private void Update() {
        if (fireHeld && allowHold) {
            if (readyToShoot && !reloading && clipAmmo > 0 && GunManager.canFire) {
                bulletsShot = 0;
                Fire();
            }
        }
    }

    public virtual void OnPrimaryFire() {
        if (readyToShoot && !reloading && clipAmmo > 0 && GunManager.canFire) {
            bulletsShot = 0;
            Fire();
        }
    }

    public virtual void HeldFire(InputAction.CallbackContext context) {
        float value = context.ReadValue<float>();
        if (allowHold) {
            fireHeld = value >= 0.9f;
            Debug.Log(value);
        }
    }

    public virtual void OnAlternateFire() {
        if (PlayerStats.Moxie > moxieRequirement && GunManager.canFire) AltFire();

    }

    public virtual void OnReload() {
        if (clipAmmo < maxClipAmmo && !reloading) ReloadDelay();
    }

    public virtual void Fire() {
        readyToShoot = false;
        FindObjectOfType<AudioManager>().Play(soundName, gameObject);
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
        clipAmmo--;
        bulletsShot++;

        if (allowInvoke) {
            Invoke("ResetShot", 1 / fireRate);
            allowInvoke = false;
        }

        if (bulletsShot < bulletsPerShot && clipAmmo > 0) {
            Invoke("ShootProjectile", 1 / (fireRate * bulletsPerShot));
        }
    }

    protected void ResetShot() {
        animator.SetBool("isShooting", false);
        readyToShoot = true;
        allowInvoke = true;
    }

    public virtual void AltFire() {
        PlayerStats.Moxie -= moxieRequirement;
        animator.SetTrigger("altFire");
        FindObjectOfType<AudioManager>().Play("Moxie", gameObject);
    }

    public void ReloadDelay() {
        reloading = true;
        Invoke("Reload", reloadTime);
        FindObjectOfType<AudioManager>().Play("Reload", gameObject);
    }

    public void Reload() {
        animator.SetTrigger("isReloading");

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

    protected virtual void OnEnable() {
        controls.Gameplay.PrimaryFire.performed += HeldFire;
        controls.Gameplay.PrimaryFire.canceled += HeldFire;
        controls.Gameplay.PrimaryFire.Enable();
    }

    protected virtual void OnDisable() {
        controls.Gameplay.PrimaryFire.performed -= HeldFire;
        controls.Gameplay.PrimaryFire.canceled -= HeldFire;
        controls.Gameplay.PrimaryFire.Disable();

    }

}
