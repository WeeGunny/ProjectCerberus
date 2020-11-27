using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTriggerCollider : MonoBehaviour
{

    [SerializeField] private Shop_UI shopUI;

    private void OnTriggerEnter(Collider collider)
    {

            shopUI.ShowShop();
    }

    private void OnTriggerExit(Collider collider)
    {
            shopUI.HideShop();
    }
}
