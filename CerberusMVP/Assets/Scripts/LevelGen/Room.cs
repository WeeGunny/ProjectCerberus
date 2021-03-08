using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Room : MonoBehaviour {
    // Array of available doorways
    public Doorway[] doorways;

    //lists of spawn points, used spawn points and prefabs to used for enemies
    public List<GameObject> enemyPrefabs = new List<GameObject>();
    public List<GameObject> enemySPs = new List<GameObject>();
    private List<GameObject> usedSPs = new List<GameObject>();

    // List of spawn points, used spawn points and prefabs for items
    public List<GameObject> itemPrefabs = new List<GameObject>();
    public List<GameObject> itemSPs = new List<GameObject>();
    private List<GameObject> usedItemSPs = new List<GameObject>();
    public int enemiesToSpawn, itemsToSpawn;
    public int enemiesAlive = 0;
    public int id = 1;
    public bool roomHasEnemies = false;
    public bool doorsLocked = false;



    // Property to contain bounds of Room
    public Bounds RoomBounds {
        get {
            return CalculateLocalBounds();
        }
    }
    // Calculate local bounds
    private Bounds CalculateLocalBounds() {
        Quaternion currentRotation = this.transform.rotation; // Get whatever the current rotation is of this object
        this.transform.rotation = Quaternion.Euler(0f, 0f, 0f); // Remove any rotation
        Bounds roomBounds = new Bounds(this.transform.position, this.transform.localScale); // Create a new Bounding Box centered on the objects position & the scale of the parent object

        foreach (Renderer renderer in GetComponentsInChildren<Renderer>()) // For every child GameObject of this Game Object, find a Renderer
            if (roomBounds == new Bounds(Vector3.zero, Vector3.zero)) {
                roomBounds = renderer.bounds; // if the bounds has no content, then make it equal to the first renderer
            }
            else {
                roomBounds.Encapsulate(renderer.bounds);  // Make the bounds include the local bounds of the renderer
            }
        this.transform.rotation = currentRotation;

        return roomBounds; // returns the new encapsulated bounds

    }

    private void Start() {
        SpawnEnemies();
        SpawnItems();
    }
    private void Update() {

        roomHasEnemies = enemiesAlive > 0;

        if (!roomHasEnemies && doorsLocked) {
            UnlockDoors();
        }

        if (PlayerManager.player && RoomBounds.Contains(PlayerManager.player.transform.position)) {
            if (roomHasEnemies && !doorsLocked) {
                LockDoors();
            }
        }
    }

    public void SpawnEnemies() {
        if (enemiesToSpawn > 0) {

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
            roomHasEnemies = true;
        }
        else {
            roomHasEnemies = false;
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

    public void ResetItems() {
        foreach (GameObject spawnPoint in usedItemSPs) {
            itemSPs.Add(spawnPoint);
        }
    }



    public void LockDoors() {
        foreach (Doorway doorway in doorways) {
            if (!doorway.isExterior) doorway.LockDoor();
        }
        doorsLocked = true;
    }

    public void UnlockDoors() {
        foreach (Doorway doorway in doorways) {
            if (!doorway.isExterior) doorway.UnlockDoor(); // Ensures not to open the doors that go outside the level
            Debug.Log("unlocking doors");
        }
        doorsLocked = false;
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(RoomBounds.center, RoomBounds.size);
    }
}


