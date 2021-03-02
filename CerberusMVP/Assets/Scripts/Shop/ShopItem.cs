using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    public Item shopItem;
    ShopUI shopUI;
    bool inShop = false;

    private void Start() {
        shopUI = ShopUI.shopUI;
    }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Return) && inShop) {
            Debug.Log("Buying Item");
            shopUI.BuyItem();
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            shopUI.ChangeItem(shopItem);
            shopUI.ShowShop();
            inShop = true;
        }
       
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            shopUI.HideShop();
            inShop = false;
        }
    }
    
}
