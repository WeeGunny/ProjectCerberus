using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop_UI : MonoBehaviour {
    private Transform container;
    private Transform shopItemTemplate;
    private IShopCustomer shopCustomer;
    // public  List<Item> allItems = new List<Item>();
    public float shopItemAmount;
    public List<Item> items = new List<Item>();

    //spawns in items into the shop
    private void Awake() {
        container = transform.Find("container");
        shopItemTemplate = container.Find("shopItemTemplate");
        shopItemTemplate.gameObject.SetActive(false);

        //for (int i =0; i<shopItemAmount; i++) {
        //    int randomIndex = Mathf.RoundToInt(Random.Range(0,allItems.Count));
        //    items.Add(allItems[randomIndex]);
        //}

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
        Transform shopItemTransform = Instantiate(shopItemTemplate, container);
        Button button = shopItemTransform.gameObject.GetComponent<Button>();
        button.onClick.AddListener(()=>TryBuyItem(item));
        shopItemTransform.gameObject.SetActive(true);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();

        //Properly positions the newly spawned shop templates
        float shopItemHeight = 100f;
        shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);

        //Sets the item name, image and cost
        shopItemTransform.Find("itemName").GetComponent<TextMeshProUGUI>().SetText(item.name);
        shopItemTransform.Find("itemPrice").GetComponent<TextMeshProUGUI>().SetText(item.cost.ToString());
        shopItemTransform.Find("itemImage").GetComponent<Image>().sprite = item.icon;
    }

    public void TryBuyItem(Item item) {
        if (PlayerManager.instance.stats.gold >= item.cost) {
            Inventory.inventory.Add(item);
        }

    }

    public void ShowShop() {
        Cursor.lockState = CursorLockMode.None;
        Debug.Log("Inshop");
        gameObject.SetActive(true);
    }

    public void HideShop() {
        Cursor.lockState = CursorLockMode.Locked;
        gameObject.SetActive(false);
    }
}
