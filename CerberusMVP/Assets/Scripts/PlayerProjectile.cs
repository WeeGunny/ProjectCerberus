using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public float speed;
    public float damage;
    public float range;
    public Vector3 direction;
    public GameObject gun;
    Rigidbody rb;
    // Start is called before the first frame update
    private void Start() {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(direction * speed *100);
    }
    // Update is called once per frame
    void Update()
    {
        
        float distance = Vector3.Distance(gun.transform.position, transform.position);
        if (distance >= range) {
            Debug.Log("Projectile Ranged out");
            DestroyProjectile();
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Enemy") {
            DestroyProjectile();
            other.GetComponent<EnemyController>().TakeDamage(damage);
            Debug.Log("Enemy Hit");
        }
        else if (other.name != "Gun" && other.tag != "Player") {
            DestroyProjectile();
            Debug.Log("bullet destroyed, hit: " + other.name);
        }

    }

    private void DestroyProjectile() {
        Destroy(gameObject);
    }

   

}
