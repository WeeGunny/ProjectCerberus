using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop_UI : MonoBehaviour
{
    private Transform container;
    private Transform shopItemTemplate;
    private IShopCustomer shopCustomer;

    //spawns in items into the shop
    private void Awake()
    {
        container = transform.Find("container");
        shopItemTemplate = container.Find("shopItemTemplate");
        shopItemTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        CreateItemButton(Shop_Item.ItemType.item1, Shop_Item.GetSprite(Shop_Item.ItemType.item1), "Item 1", Shop_Item.GetCost(Shop_Item.ItemType.item1), 0);
        CreateItemButton(Shop_Item.ItemType.item2, Shop_Item.GetSprite(Shop_Item.ItemType.item2), "Item 2", Shop_Item.GetCost(Shop_Item.ItemType.item2), 1);
        CreateItemButton(Shop_Item.ItemType.item3, Shop_Item.GetSprite(Shop_Item.ItemType.item3), "Item 3", Shop_Item.GetCost(Shop_Item.ItemType.item3), 2);
        CreateItemButton(Shop_Item.ItemType.item4, Shop_Item.GetSprite(Shop_Item.ItemType.item4), "Item 4", Shop_Item.GetCost(Shop_Item.ItemType.item4), 3);
        CreateItemButton(Shop_Item.ItemType.item5, Shop_Item.GetSprite(Shop_Item.ItemType.item5), "Item 5", Shop_Item.GetCost(Shop_Item.ItemType.item5), 4);
        CreateItemButton(Shop_Item.ItemType.item6, Shop_Item.GetSprite(Shop_Item.ItemType.item6), "Item 6", Shop_Item.GetCost(Shop_Item.ItemType.item6), 5);
        CreateItemButton(Shop_Item.ItemType.item7, Shop_Item.GetSprite(Shop_Item.ItemType.item7), "Item 7", Shop_Item.GetCost(Shop_Item.ItemType.item7), 6);

        HideShop();
    }

    //ensures items are in the correct position, and have the correct values
    private void CreateItemButton(Shop_Item.ItemType itemType, Sprite itemSprite, string itemName, int itemCost, int positionIndex)
    {
        //Duplicates the item template as a reference
        Transform shopItemTransform = Instantiate(shopItemTemplate, container);
        shopItemTransform.gameObject.SetActive(true);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();

        //Properly positions the newly spawned shop templates
        float shopItemHeight = 100f;
        shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);

        //Sets the item name, image and cost
        shopItemTransform.Find("itemName").GetComponent<TextMeshProUGUI>().SetText(itemName);
        shopItemTransform.Find("itemPrice").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());
        shopItemTransform.Find("itemImage").GetComponent<Image>().sprite = itemSprite;
    }

    private void TryBuyItem(Shop_Item.ItemType itemType)
    {
        shopCustomer.BoughtItem(itemType);
    }

    public void ShowShop(IShopCustomer shopCustomer)
    {
        this.shopCustomer = shopCustomer;
        gameObject.SetActive(true);
    }

    public void HideShop()
    {
        gameObject.SetActive(false);
    }
}
