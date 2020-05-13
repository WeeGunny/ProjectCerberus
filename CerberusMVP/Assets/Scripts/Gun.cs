
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float Damage = 10f, altDmg = 10f;
    public float bulletSpeed = 25f, altSpeed;
    public Camera fpsCam;
    public GameObject primaryAmmo,altAmmo;
    //primaryBH and altBH are the bullet hole prefab to be created;
    public GameObject primaryBH, altBH;
    public float range = 25f, altRange;
    public float moxieRequirement =20;

    private void Update() {

        if (Input.GetButtonDown("Fire1")){
            Shoot();
        }
        if (Input.GetButtonDown("Fire2") ) {
            if(PlayerManager.instance.stats.Moxie>= moxieRequirement) {
                Shoot2();
            }
            else {
                Debug.Log("Not Enough moxie to fire");
            }
            
        }
        if (Input.GetKeyDown(KeyCode.G) && PlayerManager.instance.stats.Grit > 0)
        {
            Grit();
            Debug.Log("Grit Active");
        }
        if (PlayerManager.instance.stats.GritActive == true)
        {
            PlayerManager.instance.stats.Grit -= Time.deltaTime * 10;
        }
    }


    void Shoot() {
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit)){
            Vector3 direction = (hit.point - transform.position).normalized;
           GameObject bullet = Instantiate(primaryAmmo, transform.position, Quaternion.identity);
            PlayerProjectile bulletProperties = bullet.GetComponent<PlayerProjectile>();
            bulletProperties.damage = Damage;
            bulletProperties.direction = direction;
            bulletProperties.speed = bulletSpeed;
            bulletProperties.range = range;
            bulletProperties.gun = gameObject;
            bulletProperties.bulletHolePrefab = primaryBH;
        }
    }

    void Shoot2() {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit)) {
            Vector3 direction = (hit.point - transform.position).normalized;
            GameObject bullet = Instantiate(altAmmo, transform.position, Quaternion.identity);
            PlayerProjectile bulletProperties = bullet.GetComponent<PlayerProjectile>();
            bulletProperties.damage = altDmg;
            bulletProperties.direction = direction;
            bulletProperties.speed = altSpeed;
            bulletProperties.range = altRange;
            bulletProperties.gun = gameObject;
            bulletProperties.bulletHolePrefab = altBH;
        }
        PlayerManager.instance.stats.Moxie -= moxieRequirement;
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);

    }

    void Grit()
    {
        PlayerManager.instance.stats.GritActive = !PlayerManager.instance.stats.GritActive;
        Time.timeScale = 0.2f;
    }
}
