﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {
    public float health = 10f;
    public float lookRadius = 10f;
    public float shootRadius = 5f;
    public Transform target, gun;
    NavMeshAgent agent;
    public float startShotDelay;
    private float shotDelay, distance;
    public GameObject projectile;
    // Start is called before the first frame update
    void Start() {
        agent = GetComponent<NavMeshAgent>();
        shotDelay = startShotDelay;
    }

    // Update is called once per frame
    void Update() {
        if (PlayerManager.playerExists && target == null) {
            target = PlayerManager.instance.player.transform;
        }
        if (target != null) {
            distance = Vector3.Distance(target.position, transform.position);
            if (distance <= lookRadius) {
                FaceTarget();
            }
        }


        if (distance <= lookRadius && distance >= shootRadius) {
            agent.SetDestination(target.position);
        }
        if (shotDelay <= 0 && distance <= shootRadius) {
            Shoot();
        }

        if (distance <= agent.stoppingDistance) {
            //Possible spot for melee attack trigger
            //if enemy is within their stopping distance of the player
        }


        else {
            shotDelay -= Time.deltaTime;
        }
    }

    void FaceTarget() {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    protected virtual void Shoot() {
        GameObject bullet = Instantiate(projectile, gun.position, Quaternion.identity);
        EnemyProjectile bulletProperties = bullet.GetComponent<EnemyProjectile>();
        bulletProperties.direction = transform.forward;
        shotDelay = startShotDelay;
    }

    public void TakeDamage(float damage) {
        health -= damage;
        if (health <= 0) {
            Death();
        }

    }

    protected virtual void Death() {
        Destroy(gameObject);
        Debug.Log("Enemy Has died");
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, shootRadius);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lookRadius);

    }
}