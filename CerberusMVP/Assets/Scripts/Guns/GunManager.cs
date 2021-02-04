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
    }

    // Update is called once per frame
    private void Update() {
        SwitchGun();
    }

    public void EquipGun(GameObject newGun) {
        if (gunObjects[1] == null) {
            gunObjects[1] = newGun;
        }
        else {
            Destroy(currentGunObject);
            currentGunObject = Instantiate(newGun, transform);
            gunObjects[0] = newGun;
        }
    }

    public void OnSwitchWeapon() { // this is for new input system and is mapped to switch weapon key
        if (currentGunObject == gunObjects[0] && gunObjects[0] != null) {
            currentGunObject.SetActive(false); // sets current to false and switches current gun
            currentGunObject = gunObjects[0];
        }
        else if (currentGunObject == gunObjects[1]) {
            currentGunObject.SetActive(false);
            currentGunObject = gunObjects[1];
        }
        if (currentGunObject != null) {
            currentGun = currentGunObject.GetComponent<Gun>(); // sets current gun active and pushes stats to UI
            PlayerManager.stats.activeGun = currentGun;
            currentGunObject.SetActive(true);
        }
    }

    void SwitchGun() { // this is for keyboard controls to allow switching to specific weapon
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            if (gunObjects[0] != null) {
                currentGunObject.SetActive(false); // sets current to false and switches current gun
                currentGunObject = gunObjects[0];
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            if (gunObjects[1] != null) {
                currentGunObject.SetActive(false);
                currentGunObject = gunObjects[1];
            }
        }
        if (currentGunObject != null) {
            currentGun = currentGunObject.GetComponent<Gun>(); // sets current gun active and pushes stats to UI
            PlayerManager.stats.activeGun = currentGun;
            currentGunObject.SetActive(true);
        }
    }
}
