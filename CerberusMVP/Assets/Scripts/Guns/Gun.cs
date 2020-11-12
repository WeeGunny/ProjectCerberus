
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public enum FireType { Semi, Auto, Burst, Laser };

public class Gun : MonoBehaviour {
    public GameObject gunPrefab;
    public Transform firePoint;
    public float Damage = 10f, altDmg = 10f;
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
    public FireType fireType;
    public float fireRate;
    private float lastTimeFired = 0;
    GameObject laser;
    public bool firingLaser = false;


    private void Start() {
        currentAmmo = maxAmmo;
        Reload();
    }

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

    public void ManualFire() {
        //included a firerate in manual fire so they couldn't spam the button as fast as they wanted too
        if ((Time.time - lastTimeFired) > 1 / fireRate) {
            if (ammoInClip > 0) {
                if(fireType == FireType.Semi) {
                    ShootProjectile();
                    
                }
                if(fireType == FireType.Burst) {

                    StartCoroutine("BurstFire");
                   
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

    public void LaserFire() {
        Debug.Log("Creating Laser");
        laser = Instantiate(primaryAmmo,firePoint);
        firingLaser = true;

        FindObjectOfType<AudioManager>().Play("Laser");

    }

    public IEnumerator BurstFire() {

        Debug.Log("Starting Burst fire");
        for (int b = 0; b < 3; b++) {
            if (ammoInClip > 0) {
                ShootProjectile();
                yield return new WaitForSeconds(.1f);
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
            }
        }
        else {
            beam.SetPosition(1, new Vector3( 0,0,range));
        }

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

        FindObjectOfType<AudioManager>().Play("AltFire");
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
