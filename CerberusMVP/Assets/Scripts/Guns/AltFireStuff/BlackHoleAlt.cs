using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

public class BlackHoleAlt : PlayerProjectile {

    public float pullStrength;
    public float blackHoleDuration;
    float damageCountDown = 0.5f;
    float countdown;
    protected override void Start() {
        base.Start();
        damageCountDown = FindObjectOfType<Gun>().fireRate;
        rb = GetComponent<Rigidbody>();
    }
    protected override void Update() {

        float distance = Vector3.Distance(origin, transform.position);
        if (distance >= range) {
            Debug.Log("Projectile Ranged out");
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
            rb.mass = 100f;
        }
        blackHoleDuration -= Time.deltaTime;
        if (blackHoleDuration <= 0) {
            DestroyProjectile();
        }
    }

    protected override void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag != "Player")
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        rb.mass = 100f;

    }
    private void OnTriggerEnter(Collider other) {
        countdown = damageCountDown;
    }

    private void OnTriggerStay(Collider other) {
        Rigidbody thing = other.GetComponent<Rigidbody>();
        if (thing != null && other.tag != "Player") {
            Vector3 direction = (transform.position - other.gameObject.transform.position).normalized;
            float distance = Vector3.Distance(transform.position, other.transform.position);
            float force = pullStrength / (distance * distance);
            thing.AddForce(direction * force, ForceMode.Force);
        }
        EnemyController enemy = other.GetComponent<EnemyController>();
        if (enemy != null) {
            
            countdown -= Time.deltaTime;
            if (countdown <= 0) {
                enemy.TakeDamage(damage, damageType);
                countdown = damageCountDown;
            }

        }
    }
}

