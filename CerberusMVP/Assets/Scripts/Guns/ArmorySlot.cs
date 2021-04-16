using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ArmorySlot : MonoBehaviour
{
    public GunInfo slotGun;
    public Image slotImage;
    public TextMeshProUGUI slotName;

   public void UpdateSlot(GunInfo newGun) {
        slotGun = newGun;
        slotImage.sprite = newGun.icon;
        slotName.text = newGun.itemName;
    }

    public void SelectSlot() {

        Armory.armory.UpdateGunInfoDisplay(slotGun);

    }
}
