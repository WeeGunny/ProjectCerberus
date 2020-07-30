using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleAlt : PlayerProjectile {

    public float pullStrength;
    public float blackHoleDuration;
    float damageCountDown = 0.5f;
    float countdown;
    protected override void Start() {
        base.Start();
    }
    protected override void Update() {

        float distance = Vector3.Distance(origin, transform.position);
        if (distance >= range) {
            Debug.Log("Projectile Ranged out");
            rb.mass = 100f;
        }
        blackHoleDuration -= Time.deltaTime;
        if(blackHoleDuration <= 0) {
            DestroyProjectile();
        }
    }

    protected override void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag != "Player")
        rb.velocity = Vector3.zero;
        rb.mass = 100f;

    }
    private void OnTriggerEnter(Collider other) {
        countdown = damageCountDown;
    }

    private void OnTriggerStay(Collider other) {
       Rigidbody thing = other.GetComponent<Rigidbody>();
        if (thing != null && other.tag!= "Player") {
            Vector3 direction = (transform.position - other.gameObject.transform.position).normalized;
            float distance = Vector3.Distance(transform.position,other.transform.position);
            float force = pullStrength / (distance * distance);
            thing.AddForce(direction *force,ForceMode.Force);
        }
        EnemyController enemy = other.GetComponent<EnemyController>();
        if(enemy != null) {


            countdown -= Time.deltaTime;
            if(countdown<= 0) {
                enemy.TakeDamage(damage, damageType);
                countdown = damageCountDown;
            }
           
        }
    }

    public override void SetAltStats(Gun gun) {
        base.SetAltStats(gun);
        damageCountDown = gun.fireRate;
    }
}

