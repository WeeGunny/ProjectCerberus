using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour {
    public GameObject[] gunPrefabs = new GameObject[2];
    GameObject[] gunObjects = new GameObject[2];
    public Camera fpsCam;
    public static bool canFire = true;
    Gun currentGun;
    GameObject currentGunObject;


    private void Awake() {
        if (gunPrefabs.Length > 0) {
            for (int i = 0; i < gunPrefabs.Length; i++) {
                if (gunPrefabs[i] != null) {
                    GameObject gun = Instantiate(gunPrefabs[i], transform);
                    gunObjects[i] = gun;
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start() {
        foreach (GameObject gun in gunObjects) { // sets all guns to false
            if (gun != null) gun.SetActive(false);
        }
        currentGunObject = gunObjects[0];
        currentGun = currentGunObject.GetComponent<Gun>();
        Gun altGun = gunObjects[1].GetComponent<Gun>();
        WeaponDisplay.instance.SetGun1Active();
        WeaponDisplay.instance.SetGunIcon1(currentGun.gunIcon);
        WeaponDisplay.instance.SetGunIcon2(altGun.gunIcon);

    }

    // Update is called once per frame
    private void Update() {
        SwitchGun();
    }

    public void EquipGun(GameObject newGun) {
        if (gunObjects[1] == null) { // if gun slot 2 is empty new gun fills the slot
            gunObjects[1] = newGun;
            Gun gun = newGun.GetComponent<Gun>();
            WeaponDisplay.instance.SetGunIcon2(gun.gunIcon);
        }
        else {
            Destroy(currentGunObject);
            currentGunObject = Instantiate(newGun, transform);
            gunObjects[0] = newGun;
        }
    }

    public void OnSwitchWeapon() { // this is for new input system and is mapped to switch weapon key
        if (currentGunObject == gunObjects[0] && gunObjects[1] != null) {
            currentGunObject.SetActive(false); // sets current to false and switches current gun
            currentGunObject = gunObjects[1];
        }
        else if (currentGunObject == gunObjects[1]) {
            currentGunObject.SetActive(false);
            currentGunObject = gunObjects[0];
        }
        if (currentGunObject != null) {
            currentGun = currentGunObject.GetComponent<Gun>(); // sets current gun active and pushes stats to UI
            PlayerManager.stats.activeGun = currentGun;
            // do UI animation stuff
            currentGunObject.SetActive(true);
        }
    }

    void SwitchGun() { // this is for keyboard controls to allow switching to specific weapon
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            if (gunObjects[0] != null && currentGunObject != gunObjects[0]) {
                currentGunObject.SetActive(false); // sets current to false and switches current gun
                currentGunObject = gunObjects[0];
                WeaponDisplay.instance.SetGun1Active();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            if (gunObjects[1] != null && currentGunObject != gunObjects[1]) {
                currentGunObject.SetActive(false);
                currentGunObject = gunObjects[1];
                WeaponDisplay.instance.SetGun2Active();
            }
        }
        if (currentGunObject != null) {
            currentGun = currentGunObject.GetComponent<Gun>(); // sets current gun active and pushes stats to UI
            PlayerManager.stats.activeGun = currentGun;
            currentGunObject.SetActive(true);
        }
    }
}
