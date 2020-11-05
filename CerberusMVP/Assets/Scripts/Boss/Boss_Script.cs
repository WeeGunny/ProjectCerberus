using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;

public class Boss_Script : MonoBehaviour
{
    //movement
    public float lookRadius = 10f;
    Transform target;
    UnityEngine.AI.NavMeshAgent agent;

    //attacking stuff
    public bool playerAttackable = false;
    private bool isDead = false;
    private bool isAttacking = false;
    private int randInt;

    //stats
    public int BossHealth = 15;

    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        print(target);
    }

    void update()
    {
        //Tracking player
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);

            if (distance <= agent.stoppingDistance)
            {
                playerAttackable = true;
                FaceTarget();
            }
        }

        void FaceTarget()
        {
            Vector3 direction = (target.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, lookRadius);
        }

        //Attacking
        if (playerAttackable == true && !isDead && !isAttacking)
        {
            //add animator cue here
            isAttacking = true;
            StartCoroutine(CoolDown());
            randInt = UnityEngine.Random.Range(0, 2);

            switch (randInt)
            {
                case 0:
                    Shoot();
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

    void Shoot() 
    {
        //shoots a number of bullets like a shotgun blast
        print("shooting");
    }

    void Teleport()
    {
        //teleports between one of four possible locations in the room
        print("teleporting");
    }

    void Summon()
    {
        //summons 2 smaller enemies to harrass the player
        print("summoning");
    }

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(1.5f);
        isAttacking = false;
    }

    //add some way for the boss to take damage here
    

    // add something for the boss dying here
}