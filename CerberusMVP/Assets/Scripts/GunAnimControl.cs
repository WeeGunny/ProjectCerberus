using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAnimControl : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update

    void Start()
    {
        animator = GetComponent<Animator>();

    }
    void Update()
    {
        // While Fire1 is held down, set isShooting is true
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
            animator.SetTrigger("altFire");
        }
    }
}