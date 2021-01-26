using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopEntryUI : MonoBehaviour
{
    public Image itemIcon;
    public TextMeshProUGUI itemName;
    public Item shopItem;

    public void SetItem(Item item) {
        itemIcon.sprite = item.icon;
        itemName.text = item.itemName;
        shopItem = item;
    }

    public void SelectItem() {
        if (shopItem != null)ShopUI.shopUI.ChangeItem(shopItem);
    }

}
