using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour {
    public float speed;
    public float damage;
    public float range;
    public Vector3 direction, origin;
    public GameObject bulletHolePrefab;
    public DamageType damageType;
    protected Rigidbody rb;
    // Start is called before the first frame update
    protected virtual void Start() {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(direction * speed, ForceMode.Impulse);
        origin = transform.position;
    }
    // Update is called once per frame
    protected virtual void Update() {

        float distance = Vector3.Distance(origin, transform.position);
        if (distance >= range) {
            Debug.Log("Projectile Ranged out");
            DestroyProjectile();
        }
    }

    protected virtual void OnCollisionEnter(Collision collision) {
        GameObject hit = collision.gameObject;
        //Debug.Log("You hit: " + hit.name);
        ContactPoint contact = collision.GetContact(0);
        if (hit.tag == "Enemy") {
            DestroyProjectile();
            hit.GetComponent<EnemyController>().TakeDamage(damage,damageType);
            Debug.Log("Enemy Hit");
            DmgPopUp.Create(contact.point,damage);
        }
        else if (hit.tag != "Player" && hit.tag != "Bullet") {

            GameObject hole = Instantiate(bulletHolePrefab, contact.point, Quaternion.LookRotation(contact.normal));
            hole.transform.Rotate(Vector3.right * 90);
            hole.transform.Translate(Vector3.one * 0.1f);
            DestroyProjectile();
            Debug.Log("bullet destroyed, hit: " + hit.name);
        }
    }

    public void SetStats(Gun gun) {
        speed = gun.bulletSpeed;
        damage = gun.Dmg;
        damageType = gun.damageType;
        range = gun.range;
        bulletHolePrefab = gun.primaryBH;
        direction = gun.firePoint.forward;

    }

    public virtual void SetAltStats(Gun gun) {
        speed = gun.altSpeed;
        damage = gun.altDmg;
        damageType = gun.damageType;
        range = gun.altRange;
        bulletHolePrefab = gun.altBH;
        direction = gun.firePoint.forward;

    }

    public void DestroyProjectile() {
        Destroy(gameObject);
    }



}
