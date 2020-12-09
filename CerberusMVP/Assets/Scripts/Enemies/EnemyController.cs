using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {
    [Header("Variables")]
    public float StartHealth = 10f;
    public int ammo = 20;
    public float lookRadius = 10f;
    public float attackRadius = 5f;
    public float attackDelay;
    public DamageType[] Weaknesses, Resistances;
    protected float health = 10f;

    [Header("References")]
    public Transform target;
    public Transform gun;
    public Canvas heathDisplay;
    public Image healthBar;
    public GameObject popUpPrefab;
    public LootTableGameObject lootTable;

    protected bool isDead = false, canAttack =true;
    protected NavMeshAgent agent;
    protected float distance;
    public GameObject projectile;
    public Room roomImIn;
    protected bool takingDotDamage;
    protected bool isReloading = false;

    [HideInInspector] public Animator anim;

    // Start is called before the first frame update
    protected virtual void Start() {
        agent = GetComponent<NavMeshAgent>();
        health = StartHealth;
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    protected virtual void Update() {
        if (PlayerManager.playerExists && target == null) {
            target = PlayerManager.instance.player.transform;
        }
        if (target != null && !isDead) {
            distance = Vector3.Distance(target.position, transform.position);
            if (distance <= lookRadius) {
                FaceTarget();
            }
        }


        if (distance <= lookRadius && distance >= attackRadius && !isDead) {
            agent.SetDestination(target.position);
            agent.isStopped = false;
            anim.SetBool("playerSpotted", true);
            anim.SetBool("playerAttackable", false);
        }
        if (canAttack && distance <= attackRadius && !isDead && !isReloading) {
            agent.isStopped = true;
            anim.SetBool("playerAttackable", true);
            anim.SetBool("playerSpotted", false);
            Attack();
        }

        if (distance >= lookRadius && distance >= attackRadius) {
            anim.SetBool("playerSpotted", false);
            agent.isStopped = true;
        }

        if (distance <= agent.stoppingDistance) {
            //Possible spot for melee attack trigger
            //if enemy is within their stopping distance of the player
        }

        if (ammo <= 0) {
            isReloading = true;
            anim.SetBool("outOfAmmo", true);
            StartCoroutine(reload());
        }

        UpdateHealth();

    }

    public void UpdateHealth() {
        if (health < StartHealth) {
            heathDisplay.gameObject.SetActive(true);
        }
        healthBar.fillAmount = health / StartHealth;

        if (health <= 0 && !isDead) {
            Death();
        }

    }

    protected virtual void FaceTarget() {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    protected virtual void Attack() {
        canAttack = false;
        GameObject bullet = Instantiate(projectile, gun.position, Quaternion.identity);
        EnemyProjectile bulletProperties = bullet.GetComponent<EnemyProjectile>();
        bulletProperties.direction = transform.forward;
        ammo -= 1;
        Invoke("AttackReset",attackDelay);
    }

    protected virtual void AttackReset() {
        canAttack = true;
    }

    public void TakeDamage(float damage, DamageType damageType) {
        for (int i = 0; i < Weaknesses.Length; i++) {
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
        DmgPopUp(damage);
        if (damageType.hasDOT && !takingDotDamage) {
            StartCoroutine("DotDamage", damageType);
        }
        else if (damageType.hasDOT && takingDotDamage) {
            //restart the coroutine to refresh ticks without them stacking
            StopCoroutine("DotDamage");
            StartCoroutine("DotDamage", damageType);
        }
    }

    protected IEnumerator DotDamage(DamageType type) {
        takingDotDamage = true;
        int ticksApplied = 0;
        while (ticksApplied < type.dotTicks) {
            health -= type.dotDamage;
            ticksApplied++;
            yield return new WaitForSeconds(type.dotInterval);
        }
        takingDotDamage = false;
    }

    public void DmgPopUp(float damage) {
        GameObject popUp = Instantiate(popUpPrefab,transform);
        popUp.GetComponent<DmgPopUp>().SetUp(damage);
    }

    protected IEnumerator reload() {
        yield return new WaitForSeconds(3.267f);
        ammo = 20;
        isReloading = false;
        anim.SetBool("outOfAmmo", false);
    }

    protected virtual void Death() {
        agent.isStopped = true;
        isDead = true;
        anim.SetBool("isDead", true);
        Debug.Log("Enemy Has died");
        if (roomImIn != null)
            roomImIn.enemiesAlive--;
        LootTableElementGameObject lootTableElement = lootTable.ChooseItem();
        if (lootTableElement != null) {
            GameObject loot = lootTableElement.lootObject;
            Instantiate(loot, transform.position, Quaternion.identity);
        }
    }

    protected virtual void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lookRadius);

    }
}
