﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomProjectiles : MonoBehaviour {

    //Assignables
    public Rigidbody rb;
    public GameObject explosion;
    public LayerMask whatIsTargets;
    public enum TargetType {
        Enemy, Player
    }

    public TargetType targetType;


    //Stats
    [Range(0f, 1f)]
    public float bounciness;
    public bool useGravity;

    //Damage
    public int explosionDamage;
    public float explosionRange;
    public float explosionForce;
    public DamageType damageType;

    //Lifetime
    public int maxCollisions; // Amount of times it can bounce before exploding
    public float maxLifetime; // how long before it just explods
    public bool explodeOnTouch = true; //explods on hit or always needs to time out

    int collisions;
    PhysicMaterial physics_mat;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        //When to explode:
        if (collisions >= maxCollisions) Explode();

        //Count down lifetime
        maxLifetime -= Time.deltaTime;
        if (maxLifetime <= 0) Explode();

    }
    protected virtual void OnCollisionEnter(Collision collision) {
        //Don't count collisions with other bullets
        if (collision.collider.CompareTag("Bullet")) return;

        //Count up collisions
        collisions++;

        //Explode if bullet hits an enemy directly and explodeOnTouch is activated
        if (targetType == TargetType.Enemy && collision.collider.CompareTag("Enemy") && explodeOnTouch) Explode();
        if (targetType == TargetType.Player && collision.collider.CompareTag("Player") && explodeOnTouch) Explode();
    }
    protected virtual void Explode() {
        //Instantiate explosion
        if (explosion != null) Instantiate(explosion, transform.position, Quaternion.identity,transform);

        //Check for enemies 
        Collider[] targets = Physics.OverlapSphere(transform.position, explosionRange, whatIsTargets);
        for (int i = 0; i < targets.Length; i++) {
            //Get component of enemy and call Take Damage
            if (targetType == TargetType.Enemy && targets[i].GetComponent<EnemyController>() != null) {
                targets[i].GetComponent<EnemyController>().TakeDamage(explosionDamage, damageType);
            }
            else if (targetType == TargetType.Player && targets[i].GetComponent<rbPlayer>() !=null) {
                PlayerManager.stats.TakeDamage(explosionDamage);
            }

            //Add explosion force (if enemy has a rigidbody)
            if (targets[i].GetComponent<Rigidbody>())
                targets[i].GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, explosionRange);
        }

        //Add a little delay, just to make sure everything works fine
        Invoke("Delay", 0.05f);
    }
    private void Delay() {
        Destroy(gameObject);
    }

    private void SetUp() {

        //Create a new Physic material
        physics_mat = new PhysicMaterial();
        physics_mat.bounciness = bounciness;
        physics_mat.frictionCombine = PhysicMaterialCombine.Minimum;
        physics_mat.bounceCombine = PhysicMaterialCombine.Maximum;
        //Assign material to collider
        GetComponent<SphereCollider>().material = physics_mat;

        //Set gravity
        rb.useGravity = useGravity;

    }

    /// Just to visualize the explosion range
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRange);
    }
}
