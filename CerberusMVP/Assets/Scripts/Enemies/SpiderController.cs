using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiderController : EnemyController
{
    public GameObject HurtBox;

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
