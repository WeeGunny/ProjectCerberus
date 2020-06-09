using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    #region singleton
    public static Inventory inventory;

    private void Awake() {
        inventory = this;
        DontDestroyOnLoad(this);
    }

    #endregion

    public List<Item> items = new List<Item>();
    public int limit = 16;

    public delegate void OnItemChanged();
    public OnItemChanged OnItemChangedCallBack;
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
}
