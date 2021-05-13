using System.Collections;
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

    private void Awake() {
        shopUI = this;
        SetItems();
        HideShop();
    }
    private void SetItems() {
        if (allShopItems.Count != 0) {
            for (int i = 0; i < itemAmount;) {
                int randomItem = Random.Range(0, allShopItems.Count);
                if (!currentShopItems.Contains(allShopItems[randomItem])) {
                    currentShopItems.Add(allShopItems[randomItem]);
                    i++;
                }
            }
            foreach (ItemInfo item in currentShopItems) {
                GameObject shopSlot = Instantiate(shopSlotPrefab, shopSlotsParent.transform);
                shopSlot.GetComponent<ShopItemSlot>().SetItem(item);
            }
        }
    }

    public void FillDisplays(GameObject display1, GameObject display2, GameObject display3) {

        if (currentShopItems[0]) {
            ChangeItem(currentShopItems[0]);
            Instantiate(currentShopItems[0].shopModel, display1.transform);
        }
        if (currentShopItems[1]) Instantiate(currentShopItems[1].shopModel, display2.transform);
        if (currentShopItems[2]) Instantiate(currentShopItems[2].shopModel, display3.transform);

    }

    public void ChangeItem(ItemInfo newItem) {
        itemName.text = newItem.itemName;
        itemDecription.text = newItem.description;
        itemPrice.text = "Price: " + newItem.cost.ToString() + "g";
        itemIcon.sprite = newItem.icon;
        selectedItem = newItem;
    }

    public void BuyItem() {
        if (PlayerManager.stats.gold >= selectedItem.cost) {
            if (selectedItem.function.TryBuy()) PlayerManager.stats.gold -= selectedItem.cost;
        }
    }

    public void ShowShop() {
        gameObject.SetActive(true);
        rbCam.LockCam();
        if(Interacter.interacterExists)Interacter.instance.IsInteracting = true;
    }

    public void HideShop() {
        gameObject.SetActive(false);
        rbCam.UnlockCam();
        if(Interacter.interacterExists)Interacter.instance.IsInteracting = false;
    }
}
