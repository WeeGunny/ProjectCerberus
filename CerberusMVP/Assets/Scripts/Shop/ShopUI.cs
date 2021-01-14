using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopUI : MonoBehaviour {

    public TextMeshProUGUI itemName, itemDecription, itemPrice;
    public Image itemIcon;
    Item itemInShop;
    GameObject shopItemObject;
    public static ShopUI shopUI;
    private void Start() {
        shopUI = this;
        HideShop();
    }

    public void ChangeItem(Item newItem,GameObject newItemObject) {
        itemName.text = newItem.itemName;
        itemDecription.text = newItem.description;
        itemPrice.text = "Price: "+ newItem.cost.ToString() +"g";
        itemIcon.sprite = newItem.icon;
        itemInShop = newItem;
        shopItemObject = newItemObject;
    }

    public void BuyItem() {
        if (PlayerStats.gold>=itemInShop.cost) {
            itemInShop.OnPickup();
            PlayerStats.gold -= itemInShop.cost;
            Destroy(shopItemObject);
            HideShop();
        }
        
    }

    public void ShowShop() {
        gameObject.SetActive(true);
    }

    public void HideShop() {
        gameObject.SetActive(false);
    }
}
