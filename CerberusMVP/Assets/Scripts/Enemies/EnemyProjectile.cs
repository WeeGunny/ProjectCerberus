using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour {
    public float damage = 10;
    // Start is called before the first frame update
    void Start() {

    }

    private void OnCollisionEnter(Collision collision) {
        GameObject other = collision.gameObject;
        if (other.CompareTag("Player")) {
            DestroyProjectile();
            //Debug.Log("Player Hit");
            PlayerManager.stats.TakeDamage(damage);
        }
        else if (other.CompareTag("Enemy") || other.CompareTag("Bullet")) {
            Debug.Log("Hit Enemy");
        }
        else {
            DestroyProjectile();
            //Debug.Log("bullet destroyed, hit: " + other.name);
        }

    }

    private void DestroyProjectile() {
        Destroy(gameObject);
    }
}
