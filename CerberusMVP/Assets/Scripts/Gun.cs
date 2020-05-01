
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float Damage =10f;
    public float bulletSpeed = 25f;
    public Camera fpsCam;
    public GameObject ammo;
    public float range = 25f;

    private void Update() {

        if (Input.GetButtonDown("Fire1")){
            Shoot();
        }
    }

    void Shoot() {
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit)){
            Vector3 direction = (hit.point - transform.position).normalized;
           GameObject bullet = Instantiate(ammo, transform.position, Quaternion.identity);
            PlayerProjectile bulletProperties = bullet.GetComponent<PlayerProjectile>();
            bulletProperties.damage = Damage;
            bulletProperties.direction = direction;
            bulletProperties.speed = bulletSpeed;
            bulletProperties.range = range;
            bulletProperties.gun = gameObject;
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);

    }
}
