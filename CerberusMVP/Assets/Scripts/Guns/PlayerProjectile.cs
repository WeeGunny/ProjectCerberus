using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour {
    public float damage;
    public float range;
    protected Vector3 origin;
    public GameObject bulletHolePrefab;
    public DamageType damageType;
    protected Rigidbody rb;
    // Start is called before the first frame update
    protected virtual void Start() {
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
        if (hit.tag == "Enemy") {
            DestroyProjectile();
            hit.GetComponent<EnemyController>().TakeDamage(damage,damageType);
            Debug.Log("Enemy Hit");
        }
        else if (hit.tag != "Player" && hit.tag != "Bullet") {
            DestroyProjectile();
        }
    }

    public void DestroyProjectile() {
        Destroy(gameObject);
    }



}
