using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UseType { Pickup, Inventory }
[CreateAssetMenu(fileName = "New Item", menuName ="Inventory/Item")]
public class Item : ScriptableObject
{

    public new string name = "New Item";
    public Sprite icon = null;
    public UseType useType;
    public float cost;

    public virtual void Use() {
        Debug.Log("Using " + name);
    }
}
