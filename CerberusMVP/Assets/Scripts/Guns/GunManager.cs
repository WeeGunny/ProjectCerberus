using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class GunManager : MonoBehaviour {
    public GameObject primaryGunObject, secondaryGunObject;
    public Camera fpsCam;
    public static bool canFire = true;
    public Gun currentGun, primaryGun, secondaryGun;
    [SerializeField] GameObject currentGunObject;
    StatsSO stats;
    public static GunManager instance;
    public GunGrips managerGrips;

    private void Awake() {
        instance = this;
        stats = PlayerManager.stats;
        if (!stats.isSetUp) {
            stats.SetUpStats();
        }
        if (stats.PrimaryGun) {
            primaryGunObject = Instantiate(stats.PrimaryGun.gun.gunPrefab, transform);
            primaryGun = primaryGunObject.GetComponent<Gun>();
            currentGunObject = primaryGunObject;
            currentGun = primaryGun;
        }
        if (stats.SecondaryGun) {
            secondaryGunObject = Instantiate(stats.SecondaryGun.gun.gunPrefab, transform);
            secondaryGun = secondaryGunObject.GetComponent<Gun>();
            if (!primaryGun) {
                currentGunObject = secondaryGunObject;
                currentGun = secondaryGun;
            }
            else secondaryGunObject.SetActive(false);
        }

    }

    // Start is called before the first frame update
    void Start() {
        if (primaryGun) WeaponDisplay.instance.SetGunIcon1(currentGun.gunInfo.icon);
        if (secondaryGun) WeaponDisplay.instance.SetGunIcon2(secondaryGun.gunInfo.icon);
        if (primaryGun && secondaryGun) WeaponDisplay.instance.SetGun1Active();
        if (primaryGun && !secondaryGun) WeaponDisplay.instance.OnlyPrimary();
        if (secondaryGun && !primaryGun) WeaponDisplay.instance.OnlySecondary();
    }

    // Update is called once per frame
    private void Update() {
        SelectGunByKey();
        SetHandGrips();
    }

    public void EquipGun(Gun newGun) {
        if (!secondaryGunObject) { // if gun slot 2 is empty new gun fills the slot
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
            WeaponDisplay.instance.SetGun1Active();
        }
    }

    public void ChangeLoadout(Gun newPrimary, Gun newAlt) {
        currentGun = null;
        currentGunObject = null;
        if (newPrimary) {
            Destroy(primaryGunObject);
            primaryGunObject = Instantiate(newPrimary.gunPrefab, transform);
            primaryGun = primaryGunObject.GetComponent<Gun>();
            WeaponDisplay.instance.SetGunIcon1(newPrimary.gunInfo.icon);
            currentGunObject = primaryGunObject;
            currentGun = primaryGun;
            if (!newAlt) WeaponDisplay.instance.OnlyPrimary();
        }
        if (newAlt) {
            Destroy(secondaryGunObject);
            secondaryGunObject = Instantiate(newAlt.gunPrefab, transform);
            secondaryGun = secondaryGunObject.GetComponent<Gun>();
            WeaponDisplay.instance.SetGunIcon2(newAlt.gunInfo.icon);
            if (!newPrimary) {
                currentGunObject = secondaryGunObject;
                currentGun = secondaryGun;
                WeaponDisplay.instance.OnlySecondary();
            }
            else {
                secondaryGunObject.SetActive(false);
                WeaponDisplay.instance.SetGun1Active();
            }
        }

    }

    public void OnSwitchWeapon() { // this is for new input system and is mapped to switch weapon key
        if (currentGunObject != primaryGunObject && primaryGunObject) {
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
            currentGun.gripInfo.setFingerPosition(managerGrips);
            currentGunObject.SetActive(true);
        }
    }

    void SelectGunByKey() { // this is for keyboard controls to allow switching to specific weapon
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            if (primaryGunObject && currentGunObject != primaryGunObject) {
                currentGunObject.SetActive(false); // sets current to false and switches current gun
                currentGunObject = primaryGunObject;
                currentGun = primaryGun;
                currentGun.gripInfo.setFingerPosition(managerGrips);
                currentGunObject.SetActive(true);
                WeaponDisplay.instance.SetGun1Active();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            if (secondaryGunObject && currentGunObject != secondaryGunObject) {
                currentGunObject.SetActive(false);
                currentGunObject = secondaryGunObject;
                currentGun.gripInfo.setFingerPosition(managerGrips);
                currentGun = secondaryGun;
                WeaponDisplay.instance.SetGun2Active();
            }
        }
        if (currentGun) {
            PlayerManager.stats.CurrentGun = currentGun.gunInfo;
            currentGunObject.SetActive(true);
        }
    }

    void SetHandGrips() {
        if (currentGun) {
            if (managerGrips.leftGrip.position != currentGun.gripInfo.leftGrip.position && managerGrips.rightGrip.position != currentGun.gripInfo.rightGrip.position) {
                currentGun.gripInfo.SetGripPosition(managerGrips);
            }
        }
    }

    private void OnDisable() {
        stats.SaveGuns(primaryGun.gunInfo, secondaryGun.gunInfo, currentGun.gunInfo);
    }

    private void OnApplicationQuit() {
        stats.ResetValues();
    }
}
