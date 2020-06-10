using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop_Item : MonoBehaviour
{
    public Item shopItem;
    public TextMeshProUGUI itemName,itemPrice;
    public Image itemIcon;

    public void setItem(Item newItem) {
        shopItem = newItem;
        itemName.text = newItem.name;
        itemPrice.text = newItem.cost.ToString();
        itemIcon.sprite = newItem.icon;
    }

    public void BuyItem() {
        Shop_UI.TryBuyItem(shopItem);
    }
    
}
