using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopUI : MonoBehaviour {

    public TextMeshProUGUI itemName, itemDecription, itemPrice;
    public Image itemIcon;
    public GameObject shopEntryPrefab, shopEntryParent;
    public int itemAmount;
    public List<Item> allShopItems = new List<Item>();
    List<Item> currentShopItems = new List<Item>();
    Item selectedItem;
    GameObject shopItemObject;
    public static ShopUI shopUI;
    private void Start() {
        shopUI = this;
        SetItems();
        HideShop();
    }
    private void SetItems() {
        for (int i = 0; i < itemAmount && i < allShopItems.Count; i++) {
            int randomItem = Random.Range(0, allShopItems.Count);
            currentShopItems.Add(allShopItems[randomItem]);
        }
        foreach (Item item in currentShopItems) {
            GameObject shopEntry = Instantiate(shopEntryPrefab, shopEntryParent.transform);
            shopEntry.GetComponent<ShopEntryUI>().SetItem(item);
        }

    }

    public void ChangeItem(Item newItem) {
        itemName.text = newItem.itemName;
        itemDecription.text = newItem.description;
        itemPrice.text = "Price: " + newItem.cost.ToString() + "g";
        itemIcon.sprite = newItem.icon;
        selectedItem = newItem;
        shopItemObject = newItem.itemObject;
    }

    public void BuyItem() {
        if (PlayerStats.gold >= selectedItem.cost) {
            selectedItem.OnPickup();
            PlayerStats.gold -= selectedItem.cost;
            Destroy(shopItemObject);
            HideShop();
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
