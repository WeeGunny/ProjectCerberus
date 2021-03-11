using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour {
    public GameObject[] gunPrefabs = new GameObject[2];
    public GameObject primaryGunObject, secondaryGunObject;
    public Camera fpsCam;
    public static bool canFire = true;
    Gun currentGun, primaryGun, secondaryGun;
    GameObject currentGunObject;
    public static GunManager instance;

    private void Awake() {
        instance = this;
        if (gunPrefabs[0]) {
            primaryGunObject = Instantiate(gunPrefabs[0], transform);
            primaryGunObject.SetActive(false);
            primaryGun = primaryGunObject.GetComponent<Gun>();
            currentGunObject = primaryGunObject;
            currentGun = primaryGun;
        }
        if (gunPrefabs[1]) {
            secondaryGunObject = Instantiate(gunPrefabs[1], transform);
            secondaryGunObject.SetActive(false);
            secondaryGun = secondaryGunObject.GetComponent<Gun>();
            if (!primaryGun) {
                currentGunObject = secondaryGunObject;
                currentGun = secondaryGun;
            }
        }

    }

    // Start is called before the first frame update
    void Start() {
        if (primaryGun) WeaponDisplay.instance.SetGunIcon1(currentGun.gunInfo.icon);
        if (secondaryGun) WeaponDisplay.instance.SetGunIcon2(secondaryGun.gunInfo.icon);
        if (primaryGun && secondaryGun) {
            WeaponDisplay.instance.SetGun1Active();
        }
    }

    // Update is called once per frame
    private void Update() {
        SelectGunByKey();
    }

    public void EquipGun(Gun newGun) {
        if (secondaryGunObject) { // if gun slot 2 is empty new gun fills the slot
            secondaryGunObject = Instantiate(newGun.gunPrefab, transform);
            secondaryGunObject.SetActive(false);
            WeaponDisplay.instance.SetGunIcon2(newGun.gunInfo.icon);
            WeaponDisplay.instance.SetGun1Active();
        }
        else {
            Destroy(currentGunObject);
            currentGunObject = Instantiate(newGun.gunPrefab, transform);
            primaryGunObject = newGun.gunPrefab;
            WeaponDisplay.instance.SetGunIcon1(newGun.gunInfo.icon);
        }
    }

    public void ChangeLoadout(Gun newPrimary, Gun newAlt) {
        if (newPrimary) {
            Destroy(primaryGunObject);
            primaryGunObject = Instantiate(newPrimary.gunPrefab, transform);
            WeaponDisplay.instance.SetGunIcon1(newPrimary.gunInfo.icon);
            currentGunObject = primaryGunObject;
            if (!newAlt) WeaponDisplay.instance.OnlyPrimary();
        }
        if (newAlt) {
            Destroy(secondaryGunObject);
            secondaryGunObject = Instantiate(newAlt.gunPrefab, transform);
            secondaryGunObject.SetActive(false);
            WeaponDisplay.instance.SetGunIcon2(newAlt.gunInfo.icon);
            if (!newPrimary) {
                currentGunObject = secondaryGunObject;
                WeaponDisplay.instance.OnlySecondary();
            }
        }

    }

    public void OnSwitchWeapon() { // this is for new input system and is mapped to switch weapon key
        if (currentGunObject == primaryGunObject && secondaryGunObject) {
            currentGunObject.SetActive(false); // sets current to false and switches current gun
            currentGunObject = primaryGunObject;
            currentGun = primaryGun;
            WeaponDisplay.instance.SetGun1Active();
        }
        else if (currentGunObject == secondaryGunObject && primaryGunObject) {
            currentGunObject.SetActive(false);
            currentGunObject = secondaryGunObject;
            currentGun = secondaryGun;
            WeaponDisplay.instance.SetGun2Active();
        }
        if (currentGunObject) {
            PlayerManager.stats.activeGun = currentGun;
            currentGunObject.SetActive(true);
        }
    }

    void SelectGunByKey() { // this is for keyboard controls to allow switching to specific weapon
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            if (primaryGunObject && currentGunObject != primaryGunObject) {
                currentGunObject.SetActive(false); // sets current to false and switches current gun
                currentGunObject = primaryGunObject;
                currentGun = primaryGun;
                currentGunObject.SetActive(true);
                WeaponDisplay.instance.SetGun1Active();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            if (secondaryGunObject && currentGunObject != secondaryGunObject) {
                currentGunObject.SetActive(false);
                currentGunObject = secondaryGunObject;
                currentGun = secondaryGun;                
                WeaponDisplay.instance.SetGun2Active();
            }
        }
        if (currentGun) PlayerManager.stats.activeGun = currentGun;
        currentGunObject.SetActive(true);
    }
}
