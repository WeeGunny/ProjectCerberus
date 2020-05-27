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
    public int enemiesToSpawn, itemsToSpawn;
    public int enemiesAlive =0;
    public int id = -1;
    // Get the bounding box of a room
    public Bounds RoomBounds {
        //get {return boxCollider.bounds}
        get { return meshCollider.bounds; }
    }

    private void Start() {
        SpawnEnemies();
        GameEvents.current.onDoorwayTriggerExit += LockDoors;
        GameEvents.current.onEnemiesDefeated += UnlockDoors;
        SpawnItems();
    }

    private void Update()
    {
        if (id != -1)
        {
            if (enemiesAlive == 0)
            {
                GameEvents.current.EnemiesDefeated(id);
            }
        }
        
    }

    public void SpawnEnemies() {

        for (int i = 0; i < enemiesToSpawn; i++) {
            if (enemySPs.Count == 0) {
                //GameEvents.current.EnemiesDefeated(id);
                //if there are no more empty spawn points break
                break;
            }
            int randomEnemy = Random.Range(0, enemyPrefabs.Count);
            int randomSpawnPoint = Random.Range(0, enemySPs.Count);
            GameObject enemyClone = Instantiate(enemyPrefabs[randomEnemy], enemySPs[randomSpawnPoint].transform);
            enemyClone.GetComponent<EnemyController>().roomImIn = this;
            Debug.Log("Enemy Spawned");
            //adds spawn point to used spawn points, and removes it as an available spawn point.
            usedSPs.Add(enemySPs[randomSpawnPoint]);
            enemySPs.RemoveAt(randomSpawnPoint);
            enemiesAlive++;
        }

    }
    public void ResetEnemies()
    {
        foreach(GameObject spawnPoint in usedSPs)
        {
            enemySPs.Add(spawnPoint);
        }
    }

    public void SpawnItems() {

        for (int i = 0; i < itemsToSpawn; i++) {
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

    public void ResetItems()
    {
        foreach (GameObject spawnPoint in usedItemSPs)
        {
            itemSPs.Add(spawnPoint);
        }

    }



    public void LockDoors(int id)
    {
        if(id == this.id)
        {
            foreach(Doorway doorway in doorways)
            {
                doorway.gameObject.SetActive(true);
            }
        }

    }

    public void UnlockDoors(int id)
    {
        if (id == this.id)
        {
            foreach (Doorway doorway in doorways)
            {
                doorway.gameObject.SetActive(false);
            }

        }
    }
}
      

