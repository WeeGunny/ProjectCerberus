using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName ="Inventory/Item")]
public class Item : ScriptableObject
{
    public new string name = "New Item";
    public Sprite icon = null;

    public virtual void Use() {
        Debug.Log("Using " + name);
    }
}
