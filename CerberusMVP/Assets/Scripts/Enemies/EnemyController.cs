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
    public Room roomImIn;
    public DamageType[] Weaknesses, Resistances;
    public bool takingDotDamage;
    public float StartHealth = 10f;

    public LootTableGameObject lootTable;

    public Animator anim;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start() {
        agent = GetComponent<NavMeshAgent>();
        shotDelay = startShotDelay;
        health = StartHealth;
        anim = gameObject.GetComponent<Animator>();
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
            agent.isStopped = false;
            anim.SetBool("playerSpotted", true);
            anim.SetBool("playerAttackable", false);
        }
        if (shotDelay <= 0 && distance <= shootRadius) {
            agent.isStopped = true;
            anim.SetBool("playerAttackable", true);
            anim.SetBool("playerSpotted", false);
            Shoot();
        }

        if (distance >= lookRadius && distance >= shootRadius)
        {
            anim.SetBool("playerSpotted", false);
            agent.isStopped = true;
        }

        if (distance <= agent.stoppingDistance) {
            //Possible spot for melee attack trigger
            //if enemy is within their stopping distance of the player
        }
        else {
            shotDelay -= Time.deltaTime;
        }

        if (health <= 0) {
            Death();
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

    public void TakeDamage(float damage,DamageType damageType) {
        for (int i = 0; i< Weaknesses.Length;i++) {
            if (Weaknesses[i] == damageType) {
                damage *= 2;
                damageType.dotDamage *= 2;
            }
        }
        for (int i = 0; i < Resistances.Length; i++) {
            if (Resistances[i] == damageType) {
                damage *= .5f;
                damageType.dotDamage *= .5f;
            }
        }
        health -= damage;
        if (damageType.hasDOT && !takingDotDamage) {
            StartCoroutine("DotDamage",damageType);
        }
        else if(damageType.hasDOT && takingDotDamage) {
            //restart the coroutine to refresh ticks without them stacking
            StopCoroutine("DotDamage");
            StartCoroutine("DotDamage", damageType);
        }
    }

    IEnumerator DotDamage( DamageType type) {
        takingDotDamage = true;
        int ticksApplied =0 ;
        while (ticksApplied < type.dotTicks) {
            health -= type.dotDamage;
            yield return new WaitForSeconds(type.dotInterval);
            ticksApplied++;
        }
        takingDotDamage = false;
    }

    protected virtual void Death() {
        anim.SetBool("isDead", true);
        Debug.Log("Enemy Has died");
        roomImIn.enemiesAlive--;
        LootTableElementGameObject lootTableElement = lootTable.ChooseItem();
        GameObject loot = lootTableElement.lootObject;
        if (loot != null) {
            Instantiate(loot,transform.position,Quaternion.identity);
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, shootRadius);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lookRadius);

    }
}
