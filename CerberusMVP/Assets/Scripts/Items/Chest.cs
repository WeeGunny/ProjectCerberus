using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour , IInteractable{
    public GameObject bossKeyPrefab;
    public LootTableGameObject lootTable;
    public GameObject chestTopper;
    public Vector2 AmountOfItems;
    public bool isLocked = true;
    bool hasBeenLooted = false;
    public bool containsBossKey = false;
    public static List<Chest> spawnedChests = new List<Chest>();
    public static bool bossKeyPlaced = false;
    // Start is called before the first frame update
    void Start() {
        spawnedChests.Add(this);
        lootTable.SetTable();
        if(isLocked) LeanTween.color(gameObject, new Color(1, .33f, .33f), 0.1f);
    }

    public void Interact() {
        if(!isLocked && !hasBeenLooted)OpenChest();
    }

    public void OpenChest() {
        hasBeenLooted = true;
        LeanTween.rotateLocal(chestTopper, new Vector3(45, 0, 0), 1);
        int ItemsToGive = Mathf.RoundToInt(Random.Range(AmountOfItems.x, AmountOfItems.y));
        for(int i = 0; i < ItemsToGive; i++) {
            LootTableElementGameObject lootTableElement = lootTable.ChooseItem();
            if(lootTableElement != null) {
                GameObject loot = lootTableElement.lootObject;
                Instantiate(loot, transform.position, loot.transform.rotation);
            }
        }
        if (containsBossKey) Instantiate(bossKeyPrefab, transform.position, bossKeyPrefab.transform.rotation);
        LeanTween.alpha(gameObject, 0f, 3f).setDestroyOnComplete(true);

    }

    public void UnlockChest() {
        isLocked = false;      
        LeanTween.color(gameObject, Color.white, 1);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) {
            DialogueManager.dm.interactUI.SetActive(true);
        }
    }

    private void OnDestroy() {
        spawnedChests.Remove(this);
    }

}
