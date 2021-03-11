﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopUI : MonoBehaviour {

    public TextMeshProUGUI itemName, itemDecription, itemPrice;
    public Image itemIcon;
    public GameObject shopSlotPrefab, shopSlotsParent;
    public int itemAmount;
    public List<ItemInfo> allShopItems = new List<ItemInfo>();
    List<ItemInfo> currentShopItems = new List<ItemInfo>();
    ItemInfo selectedItem;
   // GameObject shopItemObject;
    public static ShopUI shopUI;
    private void Start() {
        shopUI = this;
        SetItems();
        HideShop();
    }
    private void SetItems() {
        if(allShopItems.Count != 0) {
            for (int i = 0; i < itemAmount && i < allShopItems.Count; i++) {
                int randomItem = Random.Range(0, allShopItems.Count);
                currentShopItems.Add(allShopItems[randomItem]);
            }
            foreach (ItemInfo item in currentShopItems) {
                GameObject shopSlot = Instantiate(shopSlotPrefab, shopSlotsParent.transform);
                shopSlot.GetComponent<ShopItemSlot>().SetItem(item);
            }
            if (currentShopItems[0]) ChangeItem(currentShopItems[0]);
        }
       

    }

    public void ChangeItem(ItemInfo newItem) {
        itemName.text = newItem.itemName;
        itemDecription.text = newItem.description;
        itemPrice.text = "Price: " + newItem.cost.ToString() + "g";
        itemIcon.sprite = newItem.icon;
        selectedItem = newItem;
    }

    public void BuyItem() {
        if (PlayerStats.gold >= selectedItem.cost) {           
            if(selectedItem.function.TryBuy()) PlayerStats.gold -= selectedItem.cost; 
        }
    }

    public void ShowShop() {
        gameObject.SetActive(true);
        rbCam.LockCam();
    }

    public void HideShop() {
        gameObject.SetActive(false);
        rbCam.UnlockCam();
    }
}
