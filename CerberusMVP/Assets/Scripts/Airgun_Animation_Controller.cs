using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airgun_Animation_Controller : MonoBehaviour
{
    Animator animator;
    public float MoxieCost = 1f;
    public GameObject AutoRifle;
    public ParticleSystem particle;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }


    public void PlayEffect()
    {
        particle.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            animator.SetBool("isShooting", true);
        }
        else
        {
            animator.SetBool("isShooting", false);
        }

        // Tick Reload trigger
        if (Input.GetButtonDown("Reload"))
        {
            animator.SetTrigger("isReloading");

        }

        // Tick Altfire Trigger
        if (Input.GetButtonDown("Fire2"))
        {
            animator.SetTrigger("isAltFire");

        }

        if (Input.GetButton("Sprint"))
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }

}
