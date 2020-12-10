using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossController : EnemyController {

    GameObject enemyToSpawn;
    public Transform[] minionSpawnPoints;
    public List<Transform> telePortPoints;
    Transform currentPoint;
    public float shotgunBullets, spread;
    public float actionDelayMin, actionDelayMax;

    protected override void Update() {
        if (PlayerManager.playerExists && target == null) {
            target = PlayerManager.instance.player.transform;
        }
        if (target != null && !isDead) {
            distance = Vector3.Distance(target.position, transform.position);
            if (distance <= lookRadius) {
                FaceTarget();
            }
        }
        if (canAttack) {
            float randomAction = Random.Range(0, 2);

            switch (randomAction) {

                case 0:
                    Attack();
                    break;
                case 1:
                    Teleport();
                    break;
                case 2:
                    Summon();
                    break;
                default: break;
            }

        }
    }

    void Teleport() {
        canAttack = false;
        int randomPort = Random.Range(0, telePortPoints.Count);
        telePortPoints.Add(currentPoint); //Adds current point to array, then changes it, then removes new current point
        currentPoint = telePortPoints[randomPort];
        transform.position = telePortPoints[randomPort].position;
        Debug.Log("Teleported");
        telePortPoints.Remove(currentPoint);
        float randomDelay = Random.Range(actionDelayMin, actionDelayMax);
        Invoke("AttackReset", randomDelay);
    }

    void Summon() {
        canAttack = false;
        int randomSpawn = Random.Range(0, minionSpawnPoints.Length);
        Instantiate(enemyToSpawn, minionSpawnPoints[randomSpawn], true);
        Debug.Log("Summon");
        float randomDelay = Random.Range(actionDelayMin, actionDelayMax);
        Invoke("AttackReset", randomDelay);

    }

    protected override void Attack() {
        canAttack = false;
        anim.SetBool("playerAttackable", true);
        for (int i = 0; i < shotgunBullets; i++) {
            float spreadX = Random.Range(-spread, spread);
            float spreadY = Random.Range(-spread, spread);
            GameObject bullet = Instantiate(projectile, gun.position, Quaternion.identity);
            EnemyProjectile bulletProperties = bullet.GetComponent<EnemyProjectile>();
            bulletProperties.direction = transform.forward - new Vector3(spreadX, spreadY, 0);
            ammo -= 1;
        }
        Debug.Log("attacked");
        float randomDelay = Random.Range(actionDelayMin, actionDelayMax);
        Invoke(nameof(AttackReset), randomDelay);
    }


}