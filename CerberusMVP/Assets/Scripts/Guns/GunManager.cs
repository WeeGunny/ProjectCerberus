using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Animations.Rigging;

public class GunManager : MonoBehaviour
{
    public GameObject primaryGunObject, secondaryGunObject;
    public static bool canFire = true;

    public Gun primaryGun => primaryGunObject.GetComponent<Gun>();
    public Gun SecondaryGun => secondaryGunObject.GetComponent<Gun>();
    public Gun currentGun => currentGunObject.GetComponent<Gun>();
    public GunInfo currentGunInfo => currentGun.gunInfo;
    public GunInfo primaryGunInfo => primaryGun.gunInfo;
    public GunInfo secondaryGunInfo => SecondaryGun.gunInfo;
    public GameObject currentGunObject;
    PlayerStats stats => PlayerStats.Instance;
    public static GunManager instance;
    public Action OnWeaponsChanged;

    private void Awake()
    {
        instance = this;
        if (!stats.isSetUp)
        {
            stats.SetUpStats();
        }
        if (stats.PrimaryGun)
        {
            primaryGunObject = Instantiate(stats.PrimaryGun.gun.gunPrefab, transform);
            currentGunObject = primaryGunObject;
        }
        if (stats.SecondaryGun)
        {
            secondaryGunObject = Instantiate(stats.SecondaryGun.gun.gunPrefab, transform);
            if (!primaryGunInfo)
            {
                currentGunObject = secondaryGunObject;
            }
            else secondaryGunObject.SetActive(false);
        }
        OnWeaponsChanged?.Invoke();
    }

    // Update is called once per frame
    private void Update()
    {
        SelectGunByKey();
    }

    public void EquipGun(GunInfo newGun)
    {
        if (!secondaryGunObject)
        { // if gun slot 2 is empty new gun fills the slot
            secondaryGunObject = Instantiate(newGun.itemPrefab, transform);
            secondaryGunObject.SetActive(false);
        }
        else
        {
            Destroy(currentGunObject);
            primaryGunObject = Instantiate(newGun.itemPrefab, transform);
            currentGunObject = primaryGunObject;
        }
        OnWeaponsChanged?.Invoke();
    }

    public void ChangeLoadout(GunInfo newPrimary, GunInfo newAlt)
    {
        currentGunObject = null;
        if (newPrimary)
        {
            Destroy(primaryGunObject);
            primaryGunObject = Instantiate(newPrimary.itemPrefab, transform);
            currentGunObject = primaryGunObject;
        }
        if (newAlt)
        {
            Destroy(secondaryGunObject);
            secondaryGunObject = Instantiate(newAlt.itemPrefab, transform);
            if (!newPrimary)
            {
                currentGunObject = secondaryGunObject;
            }
            else
            {
                secondaryGunObject.SetActive(false);
            }
        }
        OnWeaponsChanged?.Invoke();
    }

    public void OnSwitchWeapon()
    { // this is for new input system and is mapped to switch weapon key
        if (currentGunObject != primaryGunObject && primaryGunObject)
        {
            currentGunObject.SetActive(false); // sets current to false and switches current gun
            currentGunObject = primaryGunObject;
        }
        else if (currentGunObject == secondaryGunObject && primaryGunObject)
        {
            currentGunObject.SetActive(false);
            currentGunObject = secondaryGunObject;
        }
        if (currentGunObject)
        {
            currentGunObject.SetActive(true);
        }
        OnWeaponsChanged?.Invoke();
    }

    void SelectGunByKey()
    { // this is for keyboard controls to allow switching to specific weapon
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (primaryGunObject && currentGunObject != primaryGunObject)
            {
                currentGunObject.SetActive(false); // sets current to false and switches current gun
                currentGunObject = primaryGunObject;
                currentGunObject.SetActive(true);
                OnWeaponsChanged?.Invoke();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (secondaryGunObject && currentGunObject != secondaryGunObject)
            {
                currentGunObject.SetActive(false);
                currentGunObject = secondaryGunObject;
                currentGunObject.SetActive(true);
                OnWeaponsChanged?.Invoke();
            }
        }
    }

    private void OnDisable()
    {
        stats.SaveGuns(primaryGunInfo, secondaryGunInfo, currentGunInfo);
    }

    private void OnApplicationQuit()
    {
        stats.ResetValues();
    }
}
