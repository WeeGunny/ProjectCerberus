using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour {
    public float speed = 10;
    public float damage = 10;
    public float range = 25;
    private Transform player;
    public Vector3 target, direction;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
        player = PlayerManager.instance.player.transform;
        target = new Vector3(player.position.x, player.position.y, player.position.z);
        //direction = (target - transform.position).normalized;
        rb.AddForce(direction * speed *100);

    }

    // Update is called once per frame
    void Update() {
        if (player == null) {
            player = PlayerManager.instance.player.transform;
        }


    }

    private void OnCollisionEnter(Collision collision) {
        GameObject other = collision.gameObject;
        if (other.CompareTag("Player")) {
            DestroyProjectile();
            Debug.Log("Player Hit");
            PlayerManager.instance.stats.TakeDamage(damage);
        }
        else if (other.tag != "Enemy") {
            DestroyProjectile();
           // Debug.Log("bullet destroyed, hit: " + other.name);
        }

    }
    private void DestroyProjectile() {
        Destroy(gameObject);
    }
}
