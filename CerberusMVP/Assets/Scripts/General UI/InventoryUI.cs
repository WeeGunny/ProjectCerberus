using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    Inventory inventory;
    public GameObject inventoryUI;
    public GameObject slotPrefab;
    public Transform itemSlotParent;

    InventorySlot[] slots;
    void Start()
    {
        inventory = PlayerManager.instance.inventory;
        inventory.OnItemChangedCallBack += UpdateUI;
        for (int i =0;i < inventory.limit;i++) {
            Instantiate(slotPrefab,itemSlotParent);
        }
        slots = itemSlotParent.GetComponentsInChildren<InventorySlot>();
        inventoryUI.SetActive(false);
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) {
            ToggleInventory();       
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

    public void ClearInventory() {
        inventory.items.Clear();
        UpdateUI();
    }

    private void ToggleInventory() {

        inventoryUI.SetActive(!inventoryUI.activeSelf);
        rbCam.ToggleCam();

    }

    public void showInventory() {
        inventoryUI.SetActive(true);
        rbCam.ToggleCam();
    }

    public void HideInventory() {
        inventoryUI.SetActive(false);
        rbCam.ToggleCam();
    }

    //public void AddSlot(int slotAmount) {
    //    for (int i = 0;i<slotAmount;i++) {
    //        Instantiate(slotPrefab, itemSlotParent);
    //    }     
    //    slots = itemSlotParent.GetComponentsInChildren<InventorySlot>();
    //    UpdateUI();
    //}
}
