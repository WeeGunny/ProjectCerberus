﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossController : EnemyController {

    public string bossName;
    public GameObject enemyToSpawn;
    public List<Transform> telePortPoints, minionSpawnPoints;
    public Transform parent;
    Transform currentPoint;
    public float shotgunBullets, spread;
    public float actionDelayMin, actionDelayMax;
    public BossUI ui;

    protected override void Start() {
        health = StartHealth;
        ui = FindObjectOfType<BossUI>();
        ui.BossName.text = bossName;
        //ui.gameObject.SetActive(false);

    }
    protected override void Update() {
        if (PlayerManager.playerExists && target == null) {
            target = PlayerManager.player.transform;
        }
        if (target != null && !isDead) {
            distance = Vector3.Distance(target.position, transform.position);
            if (distance <= lookRadius) {
                FaceTarget();
            }
                    UpdateHealth();
        }

        if (canAttack) {
            float randomAction = Random.Range(0, 3);

            switch (randomAction) {

                case 0:
                    Attack();
                    break;
                case 1:
                    if (telePortPoints.Count > 0) Teleport();

                    break;
                case 2:
                    if (minionSpawnPoints.Count > 0) Summon();
                    break;
                default: break;
            }

        }
    }

    void Teleport() {
        canAttack = false;
        int randomPort = Random.Range(0, telePortPoints.Count);
        parent.position = telePortPoints[randomPort].position;
        Debug.Log("Teleported");
        float randomDelay = Random.Range(actionDelayMin, actionDelayMax);
        Invoke("AttackReset", randomDelay);
    }

    void Summon() {
        canAttack = false;
        int randomSpawn = Random.Range(0, minionSpawnPoints.Count);
        if (enemyToSpawn != null) Instantiate(enemyToSpawn, minionSpawnPoints[randomSpawn], true);
        Debug.Log("Summon");
        float randomDelay = Random.Range(actionDelayMin, actionDelayMax);
        Invoke("AttackReset", randomDelay);

    }

    protected override void Attack() {
        canAttack = false;
        anim.SetBool("playerAttackable", true);
        float attackAnimationTime = anim.GetCurrentAnimatorStateInfo(0).length;
        float randomDelay = Random.Range(attackAnimationTime, actionDelayMax);
        Invoke(nameof(AttackReset), randomDelay);
    }

    // In current setup shoot is called by attack animation event so it shoot projectiles when mouth is fully open
    private void Shoot() {
        for (int i = 0; i < shotgunBullets; i++) {
            float spreadX = Random.Range(-spread, spread);
            float spreadY = Random.Range(-spread, spread);
            GameObject bullet = Instantiate(projectile, firePoint.transform.position, Quaternion.identity);
            Vector3 direction = target.position - firePoint.position;
            EnemyProjectile bulletProperties = bullet.GetComponent<EnemyProjectile>();
            direction = direction + new Vector3(spreadX, spreadY, 0);
            bullet.GetComponent<Rigidbody>().AddForce(direction*10,ForceMode.Impulse);
        }
    }

    protected override void AttackReset() {
        base.AttackReset();
        anim.SetBool("playerAttackable", false);
    }
    public override void UpdateHealth() {
        if (target != null && distance <= lookRadius) {
            ui.gameObject.SetActive(true);
        }
        ui.healthBar.fillAmount = health / StartHealth;
        Debug.Log("Current Health is: " + health);

        if (health <= 0 && !isDead) {
            Death();
        }
    }

    protected override void Death() {
        isDead = true;
        healthDisplay.SetActive(false);
        anim.SetBool("isDead", true);
        LootTableElementGameObject lootTableElement = lootTable.ChooseItem();
        if (lootTableElement != null) {
            GameObject loot = lootTableElement.lootObject;
            Instantiate(loot, transform.position, Quaternion.identity);
        }
        Destroy(gameObject, 5);
    }
}
