using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopUI : MonoBehaviour {

    public TextMeshProUGUI itemName, itemDecription, itemPrice;
    public Image itemIcon;
    Item itemInShop;
    private void Start() {
        HideShop();
    }

    public void ChangeItem(Item newItem) {
        itemName.text = newItem.itemName;
        itemDecription.text = newItem.description;
        itemPrice.text = newItem.cost.ToString();
        itemIcon.sprite = newItem.icon;
        itemInShop = newItem;
    }

    public void BuyItem() {
        PlayerStats stats = PlayerManager.instance.stats;
        if (stats.gold>=itemInShop.cost) {
            itemInShop.OnPickup();
            stats.gold -= itemInShop.cost;
        }
        
    }

    public void ShowShop() {
        gameObject.SetActive(true);
    }

    public void HideShop() {
        gameObject.SetActive(false);
    }
}
