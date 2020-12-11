﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAnimControl : MonoBehaviour {
    Animator animator;
    Transform CoreBoneTransform;
    public GameObject BlackHoleGun;
    Gun gun;

    void Start() {
        animator = GetComponent<Animator>();
        //CoreBoneTransform = BlackHoleGun.transform.Find("BHG_RIG.001/Core");
        gun = GetComponent<Gun>();


    }
    void Update() {
        // While Fire1 is held down, set isShooting is true
        if (Input.GetButton("Fire1")) {
            animator.SetBool("isShooting", true);
        }
        else {
            animator.SetBool("isShooting", false);
        }

        // Tick Reload trigger
        if (Input.GetButtonDown("Reload")) {
            animator.SetTrigger("isReloading");

        }

        //// Tick Altfire Trigger
        if (Input.GetButtonDown("Fire2")) {
            animator.SetTrigger("altFire");

        }

        //CoreBoneTransform.localScale = new Vector3(0.01f, 0.01f, 0.01f) * PlayerManager.instance.stats.Moxie;
        //if (PlayerManager.instance.stats.Moxie < gun.moxieRequirement) {
        //    CoreBoneTransform.localScale = new Vector3(0f, 0f, 0f);
        //}

    }
}