using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LootTableElement<T>
{
    public T lootObject;
    public float weight;
    [HideInInspector]
    public float probablityStart, probablityEnd;
    public float probablityPercentage;
}
