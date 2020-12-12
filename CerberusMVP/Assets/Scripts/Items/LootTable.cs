using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LootTable<T,U> where T:LootTableElement<U> {

    public List<T> lootItems = new List<T>();
    float totalWeight;


    public void SetTable() {
        float currentWeight = 0;

        for (int i = 0; i > lootItems.Count; i++) {
            lootItems[i].probablityStart = currentWeight;
            currentWeight += lootItems[i].weight;
            lootItems[i].probablityEnd = currentWeight;


        }
        totalWeight = currentWeight;
    }
    public T ChooseItem() {
        float pickedNumber = Random.Range(0, totalWeight);

        foreach (T loot in lootItems) {
            if (pickedNumber > loot.probablityStart && pickedNumber < loot.probablityEnd) {
                return loot;
            }
        }

        Debug.Log("No Item to return!");
        return null;
    }
}
