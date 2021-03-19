using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItemSlot : MonoBehaviour
{
    public Image itemIcon;
    public TextMeshProUGUI itemName;
    public ItemInfo slotItem;

    public void SetItem(ItemInfo item) {
        itemIcon.sprite = item.icon;
        itemName.text = item.itemName;
        slotItem = item;
    }

    public void SelectItem() {
        if (slotItem != null)ShopUI.shopUI.ChangeItem(slotItem);
    }

}
