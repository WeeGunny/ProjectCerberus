using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : ScriptableObject
{
    public List<InventorySlot> inventorySlots = new List<InventorySlot>();

    public void AddItem(ItemInfo item, int amount) {
        bool hasItem = false;
        for(int i =0; i<inventorySlots.Count; i++) {
            if (inventorySlots[i].slotItem == item) {
                inventorySlots[i].AddAmount(amount);
                hasItem = true;
                break;
            }
        }
        if (!hasItem) {
            inventorySlots.Add(new InventorySlot(item,amount));
        }
    }
}

[System.Serializable]
public class InventorySlot {
    public ItemInfo slotItem;
    public int amount;
    public InventorySlot(ItemInfo newItem, int newAmount ) {
        slotItem = newItem;
        amount = newAmount;
    }

    public void AddAmount(int value) {
        amount += value;
    }
}
