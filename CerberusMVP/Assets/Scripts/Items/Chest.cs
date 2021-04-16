using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour , IInteractable{
    public LootTableGameObject lootTable;
    public GameObject chestTopper;
    public Vector2 AmountOfItems;
    public bool isLocked = true;
    // Start is called before the first frame update
    void Start() {
        lootTable.SetTable();
        if(isLocked) LeanTween.color(gameObject, new Color(1, .33f, .33f), 0.1f);
    }

    // Update is called once per frame
    void Update() {

    }

    public void Interact() {
        if(!isLocked)OpenChest();
    }

    public void OpenChest() {
        int ItemsToGive = Mathf.RoundToInt(Random.Range(AmountOfItems.x, AmountOfItems.y));
        for(int i = 0; i < ItemsToGive; i++) {
            LootTableElementGameObject lootTableElement = lootTable.ChooseItem();
            if(lootTableElement != null) {
                GameObject loot = lootTableElement.lootObject;
                Instantiate(loot, transform.position, Quaternion.identity);
            }
        }
        LeanTween.alpha(gameObject, 0f, 3f).setDestroyOnComplete(true);

    }

    public void UnlockChest() {
        isLocked = false;
        LeanTween.rotateLocal(chestTopper, new Vector3(45, 0, 0), 1);
        LeanTween.color(gameObject, Color.white, 1);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) {
            DialogueManager.dm.interactUI.SetActive(true);
        }
    }

}
