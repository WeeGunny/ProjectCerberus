
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class Gun : MonoBehaviour {
    public GameObject gunPrefab;
    public Transform firePoint;
    public float Dmg = 10f, altDmg = 10f;
    public DamageType damageType;
    public float bulletSpeed = 25f, altSpeed = 25f;
    //These are the bullet prefabs to shoot, if laser put laser prefab here
    public GameObject primaryAmmo, altAmmo;
    //primaryBH and altBH are the bullet hole prefab to be created;
    public GameObject primaryBH, altBH;
    //how far the bullet will travel before they range out
    public float range = 25f, altRange;
    public float moxieRequirement = 20;
    public float maxAmmo, maxClipAmmo;
    public float ammoInClip, currentAmmo;
    //FireRate is shots per second
    public float fireRate = 1;
    protected float lastTimeFired = 0;



    private void Start() {
        currentAmmo = maxAmmo;
        Debug.Log("Loaded Gun");
        Reload();
    }

<<<<<<< HEAD
    protected virtual void Update() {
=======
    private void Update() {


        if (Input.GetKeyDown(KeyCode.R) && ammoInClip < maxClipAmmo) {
            Reload();
            FindObjectOfType<AudioManager>().Play("Reload");
        }
        if(laser != null && !firingLaser) {
           Debug.Log("laser Destroyed");
            Destroy(laser);
        }
    }
>>>>>>> Boss

       
    }

    public virtual void Fire() {
      

    }

    public virtual void OnFireHeld() {

        FindObjectOfType<AudioManager>().Play("Laser");

    }

    public virtual void EndFire() {

    }

    public void ShootProjectile() {
        GameObject bullet = Instantiate(primaryAmmo, firePoint.position, Quaternion.identity);
        PlayerProjectile bulletProperties = bullet.GetComponent<PlayerProjectile>();
        bulletProperties.SetStats(this);
        lastTimeFired = Time.time;
        ammoInClip--;

    }
<<<<<<< HEAD
    public virtual IEnumerator BurstFire() {

        for (int b = 0; b < 3; b++) {
            Debug.Log("Burst fire");
            if (ammoInClip > 0) {
                ShootProjectile();
                yield return new WaitForSecondsRealtime(0.1f);
=======
    public void UpdateLaser() {
        LineRenderer beam = laser.GetComponentInChildren<LineRenderer>();
        RaycastHit hit;
        if(Physics.Raycast(firePoint.position, firePoint.forward, out hit, range)) {
            if ((Time.time - lastTimeFired) > 1 / fireRate) {
                // will shoot 
                if (ammoInClip > 0) {
                    beam.SetPosition(1, new Vector3(0,0,hit.point.z));
                    EnemyController enemy = hit.collider.GetComponent<EnemyController>();
                    if(enemy != null) {
                        enemy.TakeDamage(Damage);
                    }
                    lastTimeFired = Time.time;
                    Debug.Log("Laser hit:" + hit.collider.name);
                    ammoInClip--;
                    FindObjectOfType<AudioManager>().Play("Laser");
                }
                else {
                    Debug.Log("Out of Ammo");
                    firingLaser = false;
                    Destroy(laser);
                }
>>>>>>> Boss
            }

        }
    }

    public virtual void AltFire() {
        GameObject bullet = Instantiate(altAmmo, firePoint.position, Quaternion.identity);
        PlayerProjectile bulletProperties = bullet.GetComponent<PlayerProjectile>();
        bulletProperties.SetAltStats(this);
        PlayerManager.instance.stats.Moxie -= moxieRequirement;

        FindObjectOfType<AudioManager>().Play("AltFire");
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);

    }

    public bool AmmoCheck() {
        if ((Time.time - lastTimeFired) > 1 / fireRate) {
            if (ammoInClip > 0) {
                return true;
            }
            else {
                Debug.Log("Out of Ammo");
            }
            
        }
        return false;

    }

    public void Reload() {
        if (ammoInClip>=maxClipAmmo) {
            return;
        }
        Debug.Log("Reloading");
        float reloadAmount = maxClipAmmo - ammoInClip;
        if (currentAmmo >= reloadAmount) {
            ammoInClip += reloadAmount;
            currentAmmo -= reloadAmount;
        }
        else {
            ammoInClip += currentAmmo;
            currentAmmo = 0;
        }

        

    }



}
