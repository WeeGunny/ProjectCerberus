using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/Item")]
public class ItemInfo : ScriptableObject
{
    public string itemName;
    [TextArea(3, 10)]
    public string description;
    public Sprite icon = null;
    public float cost;
    public GameObject itemPrefab, shopModel;
    public ItemFunction function;


}
