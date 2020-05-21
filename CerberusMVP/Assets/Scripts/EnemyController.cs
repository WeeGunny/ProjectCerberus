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
    private float shotDelay;
    public GameObject projectile;
    public bool enemyDead = false;
    public int id;
    // Start is called before the first frame update
    void Start() {
        agent = GetComponent<NavMeshAgent>();
        shotDelay = startShotDelay;
        target = transform;
    }

    // Update is called once per frame
    void Update() {
        if (target == transform && PlayerManager.playerExists) {
            target = PlayerManager.instance.player.transform;
        }
        float distance = Vector3.Distance(target.position, transform.position);
        FaceTarget();

        if (distance <= lookRadius && distance >= shootRadius) {
            agent.SetDestination(target.position);
        }

        if (distance <= agent.stoppingDistance) {
        }

        if (shotDelay <= 0) {

            if (distance <= shootRadius) {
                GameObject bullet = Instantiate(projectile, gun.position, Quaternion.identity);
                EnemyProjectile bulletProperties = bullet.GetComponent<EnemyProjectile>();
                bulletProperties.direction = transform.forward;

               // Debug.Log("shots fired");
                shotDelay = startShotDelay;
            }

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

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, shootRadius);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lookRadius);

    }

    public void TakeDamage(float damage) {
        health -= damage;
        if (health <= 0) {
            //Destroy(gameObject);
            this.gameObject.SetActive(false);
            enemyDead = true;
            GameEvents.current.EnemiesDefeated(id);
        }

    }
}
