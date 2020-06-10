using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop_UI : MonoBehaviour {
    private Transform container;
    private Transform shopItemTemplate;
    public List<Item> allItems = new List<Item>();
    public float shopItemAmount;
    public List<Item> items = new List<Item>();

    //spawns in items into the shop
    private void Awake() {
        container = transform.Find("container");
        shopItemTemplate = container.Find("shopItemTemplate");
        shopItemTemplate.gameObject.SetActive(false);

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
        Transform shopItemTransform = Instantiate(shopItemTemplate, container);
        shopItemTransform.gameObject.SetActive(true);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();
        shopItemTransform.GetComponent<Shop_Item>().setItem(item);
        //Properly positions the newly spawned shop templates
        float shopItemHeight = 100f;
        shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);
    }

    public static void TryBuyItem(Item item) {
        if (PlayerManager.instance.stats.gold >= item.cost) {
            Inventory.inventory.Add(item);
            Debug.Log("You bought: "+item.name);
        }
        else {
            Debug.Log("Not enough gold!");
        }

    }

    public void ShowShop() {
        Debug.Log("Inshop");
        gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void HideShop() {
        gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
