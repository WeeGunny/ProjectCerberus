
using System.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour {
    [Header("References")]
    public GameObject gunPrefab;
    public Animator animator;
    public Transform firePoint;
    public GunGrips gripInfo;
    public GameObject primaryAmmo, altAmmo;
    public GunInfo gunInfo;
    protected Camera fpsCam => rbCam.PlayerCam;
    [Header("Stats")]
    public float Dmg = 10f, altDmg = 10f;
    public bool useGunDamageValue;
    public float bulletSpeed = 1f, altSpeed = 1f;
    public float spread;
    public float moxieRequirement = 20;
    public float maxAmmo, maxClipAmmo;
    public float clipAmmo, currentAmmo;
    //FireRate is shots per second
    public float fireRate = 1, bulletsPerShot = 1, reloadTime;
    public bool fireHeld, readyToShoot, reloading;
    public bool allowHold;
    protected float bulletsShot;
    public string fireSoundName;
    public string AltFireSoundName;
    public string ReloadSoundName;
    protected bool allowInvoke = true;

    protected PlayerControls controls;

    protected void Awake() {
        currentAmmo = maxAmmo;
        readyToShoot = true;
        controls = new PlayerControls();
        Reload();
    }

    protected virtual void Update() {
        if (fireHeld && allowHold) {
            OnPrimaryFire();
        }
    }

    public virtual void OnPrimaryFire() {
        if (readyToShoot && !reloading && clipAmmo > 0 && GunManager.canFire) {
            bulletsShot = 0;
            Fire();
        }
        else if (readyToShoot && !reloading && clipAmmo <= 0 && GunManager.canFire) {
            ReloadDelay();
        }
    }

    public virtual void HeldFire(InputAction.CallbackContext context) {
        float value = context.ReadValue<float>();
        if (allowHold) {
            fireHeld = value >= 0.9f;
        }
    }

    public virtual void OnAlternateFire() {
        if (PlayerStats.Instance.Moxie > moxieRequirement && GunManager.canFire) AltFire();

    }

    public virtual void OnReload() {
        if (clipAmmo < maxClipAmmo && !reloading) ReloadDelay();
    }

    public virtual void Fire() {
        readyToShoot = false;
        AimAndFireProjectile(primaryAmmo);
        if (allowInvoke) {
            Invoke("ResetShot", 1 / fireRate);
            allowInvoke = false;
        }

        if (bulletsShot < bulletsPerShot && clipAmmo > 0) {
            Invoke("ShootProjectile", 1 / (fireRate * bulletsPerShot));
        }
    }

    protected void ResetShot() {
        if (animator) animator.SetBool("isShooting", false);
        readyToShoot = true;
        allowInvoke = true;
    }

    public virtual void AltFire() {
        PlayerStats.Instance.Moxie -= moxieRequirement;
        if (animator) animator.SetTrigger("isAltFire");

    }

    public void ReloadDelay() {
        reloading = true;
        if (animator) animator.SetTrigger("isReloading");
        Invoke("Reload", reloadTime);
        AudioManager.audioManager.Play(ReloadSoundName, gameObject);
    }

    public void Reload() {
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


    protected void AimAndFireProjectile(GameObject projectile)
    {
        if (fireSoundName != "") AudioManager.audioManager.Play(fireSoundName, gameObject);
        Ray ray = fpsCam.ViewportPointToRay(new Vector3(.5f, .5f, 0)); // goes to center of screen;
        RaycastHit hit;
        Vector3 targetPoint;
        GetComponent<SimpleRecoil>()?.AddRecoil();
        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(75);
        }

        Vector3 directionNoSpread = targetPoint - firePoint.position;

        float spreadX = Random.Range(-spread, spread);
        float spreadY = Random.Range(-spread, spread);
        Vector3 directionWithSpread = directionNoSpread + new Vector3(spreadX / 10, spreadY / 10, 0);

        GameObject bullet = Instantiate(projectile, firePoint.position, Quaternion.identity);
        bullet.transform.forward = directionWithSpread;
        if (useGunDamageValue) bullet.GetComponent<PlayerProjectile>().damage = Dmg;
        bullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * bulletSpeed, ForceMode.Impulse);
        clipAmmo--;
        bulletsShot++;
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
