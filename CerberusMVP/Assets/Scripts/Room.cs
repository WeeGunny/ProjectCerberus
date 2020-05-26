using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Room : MonoBehaviour {
    // Array of available doorways
    public Doorway[] doorways;
    // Remove
    public MeshCollider meshCollider;
    public MeshFilter meshFilter;

    //lists of spawn points, used spawn points and prefabs to used for both enemies and items
    public List<GameObject> enemyPrefabs = new List<GameObject>();
    public List<GameObject> enemySPs = new List<GameObject>();
    private List<GameObject> usedSPs = new List<GameObject>();

    public List<GameObject> itemPrefabs = new List<GameObject>();
    public List<GameObject> itemSPs = new List<GameObject>();
    private List<GameObject> usedItemSPs = new List<GameObject>();
    public int numOfEnemies, numOfItems;
    public int id;
    // Get the bounding box of a room
    public Bounds RoomBounds {
        //get {return boxCollider.bounds}
        get { return meshCollider.bounds; }
    }

    private void Start() {
        SpawnEnemies();
        SpawnItems();
    }

    public void SpawnEnemies() {

        for (int i = 0; i < numOfEnemies; i++) {
            if (enemySPs.Count == 0) {
                //if there are no more empty spawn points break
                break;
            }
            int randomEnemy = Random.Range(0, enemyPrefabs.Count);
            int randomSpawnPoint = Random.Range(0, enemySPs.Count);
            Instantiate(enemyPrefabs[randomEnemy], enemySPs[randomSpawnPoint].transform);
            Debug.Log("Enemy Spawned");
            //adds spawn point to used spawn points, and removes it as an available spawn point.
            usedSPs.Add(enemySPs[randomSpawnPoint]);
            enemySPs.RemoveAt(randomSpawnPoint);
        }

    }

    public void SpawnItems() {

        for (int i = 0; i < numOfItems; i++) {
            if (itemSPs.Count == 0) {
                //if there are no more empty spawn points break
                break;
            }
            int randomItem = Random.Range(0, itemPrefabs.Count);
            int randomSpawnPoint = Random.Range(0, itemSPs.Count);
            Instantiate(itemPrefabs[randomItem], itemSPs[randomSpawnPoint].transform);
            Debug.Log("Item Spawned");
            //adds spawn point to used spawn points, and removes it as an available spawn point.
            usedItemSPs.Add(itemSPs[randomSpawnPoint]);
            itemSPs.RemoveAt(randomSpawnPoint);
        }
    }
}
      

