using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    Inventory inventory;
    public GameObject inventoryUI;
    public Transform itemSlotParent;

    InventorySlot[] slots;
    void Start()
    {
        inventory = Inventory.inventory;
        inventory.OnItemChangedCallBack += UpdateUI;
        slots = itemSlotParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) {

            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
        
    }

    void UpdateUI() {

        for(int i = 0; i< slots.Length; i++) {
            if (i < inventory.items.Count) {
                slots[i].FillSlot(inventory.items[i]);
            }
            else {
                slots[i].ClearSlot();
            }
        }
    }
}
