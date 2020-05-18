using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAnimControl : MonoBehaviour
{
    Animator animator;
    public Transform CoreBoneTransform;
    public GameObject BlackHoleGun;
    public float MoxieCost = 1f;

    void Start()
    {
        animator = GetComponent<Animator>();
        CoreBoneTransform = BlackHoleGun.transform.Find("BHG_RIG.001/Core");
        Debug.Log(CoreBoneTransform.localScale + " localScale");

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
            CoreBoneTransform.localScale = new Vector3(1, 1, 1);
            Debug.Log(CoreBoneTransform.localScale + " localScale");
           
        }

        // Tick Altfire Trigger
        if (Input.GetButtonDown("Fire2"))
        {
            animator.SetTrigger("altFire");

            CoreBoneTransform.localScale -= new Vector3(0.1f, 0.1f, 0.1f) * MoxieCost;
            Debug.Log(CoreBoneTransform.localScale + " localScale");
          
        }
    }
}