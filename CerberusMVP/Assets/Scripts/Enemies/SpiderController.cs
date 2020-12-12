using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiderController : EnemyController
{
    public GameObject HurtBox;

    // Update is called once per frame
    protected override void Update()
    {
        if (PlayerManager.playerExists && target == null)
        {
            target = PlayerManager.player.transform;
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

        if (distance <= attackRadius && !isDead && canAttack)
        {
            anim.SetBool("playerAttackable", true);
            anim.SetBool("playerSpotted", false);
            Attack();
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

    protected override void Attack() {
        canAttack = false;
        agent.isStopped = true;
        anim.SetBool("playerSpotted", false);
        anim.SetBool("playerAttackable", true);
        HurtBox.SetActive(true);
        Invoke("AttackReset",attackDelay);
    }

    protected override void AttackReset() {
        base.AttackReset();
        HurtBox.SetActive(false);
        anim.SetBool("playerAttackable", false);
        agent.isStopped = false;
    }
}
