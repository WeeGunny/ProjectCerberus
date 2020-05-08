using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour {
    public float speed;
    public float damage;
    public float range;
    public Vector3 direction ,origin;
    public GameObject gun, bulletHolePrefab;
    Rigidbody rb;
    // Start is called before the first frame update
    private void Start() {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(direction * speed * 100);
        origin = transform.position;
    }
    // Update is called once per frame
    void Update() {
        
        float distance = Vector3.Distance(origin, transform.position);
        if (distance >= range) {
            Debug.Log("Projectile Ranged out");
            DestroyProjectile();
        }
    }

    private void OnCollisionEnter(Collision collision) {
        GameObject hit = collision.gameObject;
        //Debug.Log("You hit: " + hit.name);
        ContactPoint contact = collision.GetContact(0);
        if (hit.tag == "Enemy") {
            DestroyProjectile();
            hit.GetComponent<EnemyController>().TakeDamage(damage);
            Debug.Log("Enemy Hit");
        }
        else if (hit.tag != "Player" && hit.tag != "Bullet") {

            GameObject hole = Instantiate(bulletHolePrefab, contact.point, Quaternion.LookRotation(contact.normal));
            hole.transform.Rotate(Vector3.right * 90);
            hole.transform.Translate(Vector3.one * 0.1f);
            DestroyProjectile();
            Debug.Log("bullet destroyed, hit: " + hit.name);
        }
    }

    private void DestroyProjectile() {
        Destroy(gameObject);
    }



}
