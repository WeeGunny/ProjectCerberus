using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiderController : MonoBehaviour
{
    public float health = 10f;
    public float lookRadius = 10f;
    public float attackRadius = 5f;
    public Transform target;
    private bool isDead = false;
    NavMeshAgent agent;
    private float distance;
    public Room roomImIn;
    public DamageType[] Weaknesses, Resistances;
    public bool takingDotDamage;
    public float StartHealth = 10f;

    public LootTableGameObject lootTable;

    public GameObject HurtBox;
    private bool isAttacking = false;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        health = StartHealth;
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerManager.playerExists && target == null)
        {
            target = PlayerManager.instance.player.transform;
        }
        if (target != null && !isDead)
        {
            distance = Vector3.Distance(target.position, transform.position);
            if (distance <= lookRadius)
            {
                FaceTarget();
            }
        }

        if (distance <= lookRadius && distance >= attackRadius && !isDead)
        {
            agent.SetDestination(target.position);
            agent.isStopped = false;
            anim.SetBool("playerSpotted", true);
            anim.SetBool("playerAttackable", false);
        }

        if (distance <= attackRadius && !isDead && !isAttacking)
        {
            anim.SetBool("playerAttackable", true);
            anim.SetBool("playerSpotted", false);
            Bite();
        }

        if (distance >= lookRadius && distance >= attackRadius)
        {
            anim.SetBool("playerSpotted", false);
            agent.isStopped = true;
        }

        if (health <= 0 && !isDead)
        {
            Death();
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    protected virtual void Bite()
    {
        agent.isStopped = true;
        anim.SetBool("playerSpotted", false);
        anim.SetBool("playerAttackable", true);
        HurtBox.SetActive(true);
        isAttacking = true;
        StartCoroutine(lunge());
    }

    public void TakeDamage(float damage, DamageType damageType)
    {
        for (int i = 0; i < Weaknesses.Length; i++)
        {
            if (Weaknesses[i] == damageType)
            {
                damage *= 2;
                damageType.dotDamage *= 2;
            }
        }
        for (int i = 0; i < Resistances.Length; i++)
        {
            if (Resistances[i] == damageType)
            {
                damage *= .5f;
                damageType.dotDamage *= .5f;
            }
        }
        health -= damage;
        if (damageType.hasDOT && !takingDotDamage)
        {
            StartCoroutine("DotDamage", damageType);
        }
        else if (damageType.hasDOT && takingDotDamage)
        {
            //restart the coroutine to refresh ticks without them stacking
            StopCoroutine("DotDamage");
            StartCoroutine("DotDamage", damageType);
        }
    }

    IEnumerator DotDamage(DamageType type)
    {
        takingDotDamage = true;
        int ticksApplied = 0;
        while (ticksApplied < type.dotTicks)
        {
            health -= type.dotDamage;
            yield return new WaitForSeconds(type.dotInterval);
            ticksApplied++;
        }
        takingDotDamage = false;
    }

    IEnumerator lunge()
    {
        yield return new WaitForSeconds(2f);
        isAttacking = false;
        HurtBox.SetActive(false);
        anim.SetBool("playerAttackable", false);
        agent.isStopped = false;
    }

    protected virtual void Death()
    {
        agent.isStopped = true;
        isDead = true;
        anim.SetBool("isDead", true);
        Debug.Log("Enemy Has died");
        if(roomImIn != null)
        roomImIn.enemiesAlive--;
        LootTableElementGameObject lootTableElement = lootTable.ChooseItem();
        GameObject loot = lootTableElement.lootObject;
        if (loot != null)
        {
            Instantiate(loot, transform.position, Quaternion.identity);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lookRadius);

    }
}
