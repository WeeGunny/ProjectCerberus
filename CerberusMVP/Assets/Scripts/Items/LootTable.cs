using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LootTable<T,U> where T:LootTableElement<U> {

    public List<T> lootItems = new List<T>();
    [SerializeField]float totalWeight;


    public void SetTable() {
        float currentWeight = 0;
        //Loot table adds all items weights together, marking where their weight starts and ends
        for (int i = 0; i < lootItems.Count; i++) {
            lootItems[i].probablityStart = currentWeight;
            currentWeight += lootItems[i].weight;
           // totalWeight += lootItems[i].weight;
            lootItems[i].probablityEnd = currentWeight;
        }
        totalWeight = currentWeight;

        foreach(T loot in lootItems) {
            loot.probablityPercentage = (loot.weight / totalWeight) *100;
        }
    }
    public T ChooseItem() {
        float pickedNumber = Random.Range(0, totalWeight);
        //Picks a random number from the total weight and if it lands within an Items range that Item is picked
        foreach (T loot in lootItems) {
            if (pickedNumber > loot.probablityStart && pickedNumber < loot.probablityEnd) {
                return loot;
            }
        }

        Debug.Log("No Item to return!" + " : picked Number was " + pickedNumber);
        return null;
    }
}
