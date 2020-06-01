using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_Item : MonoBehaviour
{
    public enum ItemType
    {
        item1,
        item2,
        item3,
        item4,
        item5,
        item6,
        item7
    }

    public static int GetCost (ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.item1:    return 10;
            case ItemType.item2:    return 20;
            case ItemType.item3:    return 30;
            case ItemType.item4:    return 40;
            case ItemType.item5:    return 50;
            case ItemType.item6:    return 100;
            case ItemType.item7:    return 150;
        }
    }

    public static Sprite GetSprite(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.item1: return GameAssets.Instance.item1;
            case ItemType.item2: return GameAssets.Instance.item2;
            case ItemType.item3: return GameAssets.Instance.item3;
            case ItemType.item4: return GameAssets.Instance.item4;
            case ItemType.item5: return GameAssets.Instance.item5;
            case ItemType.item6: return GameAssets.Instance.item6;
            case ItemType.item7: return GameAssets.Instance.item7;
        }
    }
}
