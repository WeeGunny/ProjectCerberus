using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTriggerCollider : MonoBehaviour
{

    [SerializeField] private Shop_UI shopUI;

    private void OnTriggerEnter(Collider collider)
    {
        IShopCustomer shopCustomer = collider.GetComponent<IShopCustomer>();
        if (shopCustomer != null)
        {
            shopUI.ShowShop(shopCustomer);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        IShopCustomer shopCustomer = collider.GetComponent<IShopCustomer>();
        if (shopCustomer != null)
        {
            shopUI.HideShop();
        }
    }
}
