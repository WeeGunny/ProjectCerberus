using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {
    [Header("Variables")]
    public float StartHealth = 10f;
    public float lookRadius = 10f;
    public float attackRadius = 5f;
    public float attackDelay;
    public DamageType[] Weaknesses, Resistances;
    protected float health = 10f;

    [Header("References")]
    public Transform target;
    public Transform firePoint;
    public Transform dmgNumberPoint;
    public GameObject healthDisplay;
    public Image healthBar;
    public GameObject popUpPrefab;
    public LootTableGameObject lootTable;
    public Transform lootDropSpawnPoint;

    [Header("Sound")]
    public string hurtClip;
    public string fireClip;
    public string reloadClip;


    protected bool isDead = false, canAttack = false;
    protected NavMeshAgent agent;
    protected float distance;
    protected Transform playerCam => rbCam.PlayerCam.transform;
    public GameObject projectile;
    public Room roomImIn;
    protected bool takingDotDamage;

    [HideInInspector] public Animator anim;

    // Start is called before the first frame update
    protected virtual void Start() {
        agent = GetComponent<NavMeshAgent>();
        health = StartHealth;
        healthDisplay.SetActive(false);
        anim = gameObject.GetComponent<Animator>();
        lootTable.SetTable();
    }

    // Update is called once per frame
    protected virtual void Update() {
        if (rbPlayer.Player && target == null) {
            target = rbPlayer.Player.targetPoint;
            AttackReset();
        }
        if (target != null && !isDead) {
            distance = Vector3.Distance(target.position, transform.position);
            if (distance <= lookRadius) {
                FaceTarget();
            }
            UpdateHealth();
        }


        if (distance <= lookRadius && distance >= attackRadius && !isDead) {
            agent.SetDestination(target.position);
            agent.isStopped = false;
            anim.SetBool("playerSpotted", true);
            anim.SetBool("playerAttackable", false);
        }

        if (canAttack && distance <= attackRadius && !isDead) {
            agent.isStopped = true;
            anim.SetBool("playerAttackable", true);
            anim.SetBool("playerSpotted", false);
            Attack();
        }
        if (distance >= lookRadius && distance >= attackRadius) {
            anim.SetBool("playerSpotted", false);
            agent.isStopped = true;
        }

    }

    public virtual void UpdateHealth() {
        if (health < StartHealth) {
            healthDisplay.gameObject.SetActive(true);
        }
        healthBar.fillAmount = health / StartHealth;
        healthDisplay.transform.LookAt(healthDisplay.transform.position + playerCam.rotation * Vector3.forward, playerCam.rotation * Vector3.up);

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
        AudioManager.audioManager.Play(hurtClip, gameObject);
    }

    protected IEnumerator DotDamage(DamageType type) {
        takingDotDamage = true;
        int ticksApplied = 0;
        while (ticksApplied < type.dotTicks) {
            health -= type.dotDamage;
            ticksApplied++;
            yield return new WaitForSeconds(type.dotInterval);
        }
    }

    public void DmgPopUp(float damage) {
        GameObject popUp = Instantiate(popUpPrefab, dmgNumberPoint);
        popUp.GetComponent<DmgPopUp>().SetUp(damage);
    }


    protected virtual void Death() {
        agent.isStopped = true;
        isDead = true;
        healthDisplay.SetActive(false);
        anim.SetBool("isDead", true);
        Debug.Log("Enemy Has died");
        if (roomImIn != null) roomImIn.enemiesAlive--;
        LootTableElementGameObject lootTableElement = lootTable.ChooseItem();
        if (lootTableElement != null) {
            GameObject loot = lootTableElement.lootObject;
            Instantiate(loot, lootDropSpawnPoint.position,loot.transform.rotation);
        }
        gameObject.GetComponent<BoxCollider>().enabled = false;

        if (isDead == true) {
            if (gameObject.tag == "Weapon") {
                GetComponent<Rigidbody>().useGravity = true;
                GetComponent<Rigidbody>().isKinematic = false;
            }
        }
        Destroy(gameObject, 5);
    }

    protected virtual void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lookRadius);

    }
}
