
using UnityEngine;
using UnityEngine.Rendering;

public enum FireType { Semi, Auto, Burst, Laser };

public class Gun : MonoBehaviour {
    public GameObject gunPrefab;
    public Transform firePoint;
    public float Damage = 10f, altDmg = 10f;
    public float bulletSpeed = 25f, altSpeed = 25f;
    //These are the bullet prefabs to shoot
    public GameObject primaryAmmo, altAmmo;
    //primaryBH and altBH are the bullet hole prefab to be created;
    public GameObject primaryBH, altBH;
    //how far the bullet will travel before they range out
    public float range = 25f, altRange;
    public float moxieRequirement = 20;
    public float maxAmmo, maxClipAmmo;
    public float ammoInClip, currentAmmo;
    public FireType fireType;
    public float fireRate;
    private float lastTimeFired = 0;


    private void Start() {
        currentAmmo = maxAmmo;
        Reload();
    }

    private void Update() {


        if (Input.GetKeyDown(KeyCode.R) && ammoInClip < maxClipAmmo) {
            Reload();
        }       
    }

    public void ManualFire() {
        //included a firerate in manual fire so they couldn't spam the button as fast as they wanted too
        if ((Time.time - lastTimeFired) > 1 / fireRate) {
            if (ammoInClip > 0) {
                if(fireType == FireType.Semi) {
                    ShootProjectile();
                    
                }
                if(fireType == FireType.Burst) {

                    for(int b= 0; b<3; b++) {
                        if (ammoInClip > 0 && (Time.time - lastTimeFired) > 1 / fireRate) {
                            ShootProjectile();
                        }
                    }
                }
               
            }
            else {
                Debug.Log("Out of Ammo");
            }
        }
    }

    public void AutomaticFire() {

        if ((Time.time - lastTimeFired) > 1 / fireRate) {
            // will shoot 
            if (ammoInClip > 0) {
                ShootProjectile();
                lastTimeFired = Time.time;
            }
            else {
                Debug.Log("Out of Ammo");
            }
        }


    }
    void ShootProjectile() {

        Vector3 direction = firePoint.forward;
        GameObject bullet = Instantiate(primaryAmmo, firePoint.position, Quaternion.identity);
        PlayerProjectile bulletProperties = bullet.GetComponent<PlayerProjectile>();
        bulletProperties.damage = Damage;
        bulletProperties.direction = direction;
        bulletProperties.speed = bulletSpeed;
        bulletProperties.range = range;
        bulletProperties.gun = gameObject;
        bulletProperties.bulletHolePrefab = primaryBH;
        lastTimeFired = Time.time;
        ammoInClip--;

    }
    public void ShootBeam() {
        RaycastHit hit;
        Physics.Raycast(firePoint.position, firePoint.forward, out hit, range);
            
    }
    public virtual void AltFire() {

        Vector3 direction = firePoint.forward;
        GameObject bullet = Instantiate(altAmmo, firePoint.position, Quaternion.identity);
        PlayerProjectile bulletProperties = bullet.GetComponent<PlayerProjectile>();
        bulletProperties.damage = altDmg;
        bulletProperties.direction = direction;
        bulletProperties.speed = altSpeed;
        bulletProperties.range = altRange;
        bulletProperties.gun = gameObject;
        bulletProperties.bulletHolePrefab = altBH;

        PlayerManager.instance.stats.Moxie -= moxieRequirement;
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);

    }

    void Reload() {
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
