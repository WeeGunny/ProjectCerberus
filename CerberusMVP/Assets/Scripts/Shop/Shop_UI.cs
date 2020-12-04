using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop_UI : MonoBehaviour {
    public Transform slotParent;
    public GameObject shopSlotPrefab;
    public List<Item> allItems = new List<Item>();
    public float shopItemAmount;
    public List<Item> items = new List<Item>();

    //spawns in items into the shop
    private void Awake() {
        for (int i = 0; i < shopItemAmount;) {
            int randomIndex = Mathf.RoundToInt(Random.Range(0, allItems.Count));
            if (!items.Contains(allItems[randomIndex])) {
                items.Add(allItems[randomIndex]);
                i++;
            }
        }

    }

    private void Start() {

        for (int i = 0; i < items.Count; i++) {
            CreateItemButton(items[i], i);
        }

        HideShop();
    }

    //ensures items are in the correct position, and have the correct values
    private void CreateItemButton(Item item, int positionIndex) {
        //Duplicates the item template as a reference
        GameObject shopItem = Instantiate(shopSlotPrefab,slotParent);
        shopItem.GetComponent<Shop_Item>().setItem(item);
    }

    public static void TryBuyItem(Item item) {

        if (PlayerManager.instance.stats.gold >= item.cost) {
            if (PlayerManager.instance.inventory.Add(item)) {
                PlayerManager.instance.stats.gold -= item.cost;
                Debug.Log("You bought: " + item.name + " <br> Gold Remaining:" + PlayerManager.instance.stats.gold);
            }        
        }
        else {
            Debug.Log("Not enough gold!");
        }
    }

    public void ShowShop() {
        Debug.Log("Inshop");
        gameObject.SetActive(true);
    }

    public void HideShop() {
        gameObject.SetActive(false);
    }
}
