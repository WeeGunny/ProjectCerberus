using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour {
    public List<Gun> guns = new List<Gun>();
    public Camera fpsCam;
    public static bool canFire =true;
    Gun currentGun;
    GameObject currentGunObject;
    List<GameObject> gunObjects = new List<GameObject>();

    [Header ("Recoil")]
    public Vector3 upRecoil;
    Vector3 orignalRotation;
    public float minRotation = -1f;
    public float maxRotation = -3f;
    public float rotatationValue = 0f;


    // Start is called before the first frame update
    void Start() {
        for (int i=0;i<guns.Count;i++) {
            gunObjects.Add(Instantiate(guns[i].gunPrefab, transform));
            gunObjects[i].SetActive(false);
        }
        currentGunObject = gunObjects[0];
        currentGun = currentGunObject.GetComponent<Gun>();
        currentGunObject.SetActive(true);

        //Recoil
        orignalRotation = transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update() {
        if(currentGunObject == null) {
            canFire = false;
        }
        if (canFire) {
            CheckForShooting();
            CheckForReload();
            SwitchGun();
        }   
        
    }  

    private void CheckForShooting() {
        if (Input.GetButtonDown("Fire1")) {
            currentGun.Fire();
            AddRecoil();
        }

        if (Input.GetButton("Fire1")) {
            currentGun.OnFireHeld();
            AddRecoil();
        }
        if (Input.GetButtonUp("Fire1")) {
            currentGun.EndFire();
            StopRecoil();

        }

        if (Input.GetButtonDown("Fire2")) {
            if (PlayerManager.instance.stats.Moxie >= currentGun.moxieRequirement) {
                currentGun.AltFire();
                StopRecoil();
            }
            else {
                Debug.Log("Not Enough moxie to fire");
            }
        }
    }

    private void AddRecoil()
    {
        transform.localEulerAngles += upRecoil;
        float maxRecoil = Mathf.Clamp(rotatationValue, minRotation, maxRotation);
    }

    private void StopRecoil()
    {
        transform.localEulerAngles = orignalRotation;
    }

    private void CheckForReload() {

        if (Input.GetKeyDown(KeyCode.R)) {

            currentGun.Reload();
        }
    }

    void SwitchGun() {
        if (currentGunObject!= null) {
            currentGunObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            if (gunObjects[0] != null) {
                currentGunObject = gunObjects[0];
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            if (gunObjects[1] != null) {
                currentGunObject = gunObjects[1];
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            if (gunObjects[2] != null) {
                currentGunObject = gunObjects[2];
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4)) {
            if (gunObjects[2] != null) {
                currentGunObject = gunObjects[3];
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (gunObjects[2] != null)
            {
                currentGunObject = gunObjects[4];
            }
        }
        if (currentGunObject!= null) {
            currentGun = currentGunObject.GetComponent<Gun>();
            PlayerManager.instance.stats.activeGun = currentGun;
            currentGunObject.SetActive(true);
        }
       
    }

    public static void ToggleFire() {
        canFire = !canFire;
    }
}
