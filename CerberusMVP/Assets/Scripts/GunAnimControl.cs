using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAnimControl : MonoBehaviour
{
    Animator animator;
    Transform CoreBoneTransform;
    public GameObject BlackHoleGun;
    Gun gun;

    void Start()
    {
        animator = GetComponent<Animator>();
        CoreBoneTransform = BlackHoleGun.transform.Find("BHG_RIG.001/Core");
        Debug.Log(CoreBoneTransform.localScale + " localScale");
        gun = GetComponent<Gun>();
        

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
            Vector3 scale = CoreBoneTransform.localScale;

            scale -= new Vector3(0.01f, 0.01f, 0.01f) * gun.moxieRequirement; // increments scale down in 1/100ths * Moxie cost
            //Clamps scale at 0 and max of 1;
            scale.x = Mathf.Clamp(scale.x, 0, 1);
            scale.y = Mathf.Clamp(scale.y, 0, 1);
            scale.z = Mathf.Clamp(scale.z, 0, 1);
            CoreBoneTransform.localScale = scale;

            Debug.Log(CoreBoneTransform.localScale + " localScale");
          
        }
    }
}