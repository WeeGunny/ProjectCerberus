using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public static Inventory inventory;
    public List<Item> items = new List<Item>();
    public int limit = 16;

    public delegate void OnItemChanged();
    public OnItemChanged OnItemChangedCallBack;
    //public delegate void OnSlotIncrease(int increaseAmount);
    //public OnItemChanged OnSlotIncreaseCallBack;
    private void Awake() {
        inventory = this;
    }

    private void Start() {
        PlayerManager.instance.inventory = inventory;
        Debug.Log("Inventory set");
        DontDestroyOnLoad(this);
    }

  
    public bool Add(Item item) {

        if (items.Count >= limit) {
            Debug.Log("No space in inventory");
            return false;
        }

        items.Add(item);
        if (OnItemChangedCallBack != null) {
            OnItemChangedCallBack.Invoke();
        }


        return true;
    }

    public void Remove(Item item) {

        items.Remove(item);
        if (OnItemChangedCallBack != null) {
            OnItemChangedCallBack.Invoke();
        }
    }

    //public void IncreaseLimit(int increaseAmount) {

    //    limit += increaseAmount;
    //}
}
