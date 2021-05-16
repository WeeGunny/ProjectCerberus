using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class Armory : MonoBehaviour {
    public static List<GunInfo> UnlockedWeapons = new List<GunInfo>();
    [SerializeField] List<GunInfo> startingWeapsons = new List<GunInfo>();
    public Transform UIParent;
    public GameObject slotPrefab;
    /*[HideInInspector]*/
    public Gun tempGun1, tempGun2;
    /*[HideInInspector]*/
    public GunInfo selectedGun;
    public TextMeshProUGUI Name, Damage, AltDamage, FireRate, FireType, ReloadTime, Ammo, Descripton;
    public Image gun1Icon, gun2Icon, selectedGunIcon;
    public static Armory armory;
    List<GameObject> slotObjects = new List<GameObject>();

    private void Awake() {
        if (!armory) armory = this;
        else Destroy(gameObject);
        foreach (GunInfo gun in startingWeapsons) {
            if (!UnlockedWeapons.Contains(gun)) UnlockedWeapons.Add(gun);
        }
    }

    private void Start() {
        for (int i = 0; i < UnlockedWeapons.Count; i++) {
            ArmorySlot slot = Instantiate(slotPrefab, UIParent).GetComponent<ArmorySlot>();
            slot.UpdateSlot(UnlockedWeapons[i]);
            slotObjects.Add(slot.gameObject);
        }
        HideArmory();
    }

    public void UpdateGunInfoDisplay(GunInfo gunInfo) {
        Name.text = gunInfo.itemName;
        Damage.text = "Damage: " + gunInfo.gun.Dmg.ToString();
        AltDamage.text = "Alf Fire Damage: " + gunInfo.gun.altDmg.ToString();
        FireRate.text = "FireRate: " + gunInfo.gun.fireRate.ToString();
        if (gunInfo.gun.allowHold) FireType.text = "FireType: Automatic";
        else if (gunInfo.gun.bulletsPerShot > 1) FireType.text = "FireType: Burst";
        else FireType.text = "FireType: Manual";
        ReloadTime.text = "Reload Time: " + gunInfo.gun.reloadTime.ToString() + "s";
        Ammo.text = "Ammo: " + gunInfo.gun.maxClipAmmo + "/" + gunInfo.gun.maxAmmo;
        Descripton.text = gunInfo.description;
        selectedGunIcon.sprite = gunInfo.icon;
        selectedGun = gunInfo;

    }
    public void SelectGun1() {
        tempGun1 = selectedGun.gun;
        gun1Icon.sprite = selectedGun.icon;
    }

    public void SelectGun2() {
        tempGun2 = selectedGun.gun;
        gun2Icon.sprite = selectedGun.icon;

    }

    public void ConfirmLoadout() {
        if (tempGun1 && tempGun2) GunManager.instance.ChangeLoadout(tempGun1, tempGun2);
        else if (tempGun1 && !tempGun2) GunManager.instance.ChangeLoadout(tempGun1, null);
        else if (!tempGun1 && tempGun2) GunManager.instance.ChangeLoadout(null, tempGun2);

    }

    public void RefreshGunList() {
        foreach (GameObject slotObject in slotObjects) {
            Destroy(slotObject);
        }
        for (int i = 0; i < UnlockedWeapons.Count; i++) {
            ArmorySlot slot = Instantiate(slotPrefab, UIParent).GetComponent<ArmorySlot>();
            slot.UpdateSlot(UnlockedWeapons[i]);
            slotObjects.Add(slot.gameObject);
        }

    }

    public void ShowArmory() {
        gameObject.SetActive(true);
        rbCam.LockCam();

        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //Set a new selected object
        EventSystem.current.SetSelectedGameObject(slotPrefab);
        if (Interacter.interacterExists) Interacter.instance.IsInteracting = true;
    }

    public void HideArmory() {
        gameObject.SetActive(false);
        rbCam.UnlockCam();
        if (Interacter.interacterExists) Interacter.instance.IsInteracting = false;
    }



}
