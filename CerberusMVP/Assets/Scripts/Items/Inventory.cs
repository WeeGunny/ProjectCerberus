using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    #region singleton

    private void Awake() {
        PlayerManager.instance.inventory = this;
        DontDestroyOnLoad(this);
    }

    #endregion

    public List<Item> items = new List<Item>();
    public int limit = 16;

    public delegate void OnItemChanged();
    public OnItemChanged OnItemChangedCallBack;
    //public delegate void OnSlotIncrease(int increaseAmount);
    //public OnItemChanged OnSlotIncreaseCallBack;
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
