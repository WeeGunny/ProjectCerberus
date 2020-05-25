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
    public int numOfEnemies, numOfItems;
    


    // Property to contain bounds of Room
    public Bounds RoomBounds
    {
        get
        {
            return CalculateLocalBounds();
        }
    }
    // Calculate local bounds
    private Bounds CalculateLocalBounds()
    {
        Quaternion currentRotation = this.transform.rotation; // Get whatever the current rotation is of this object
        this.transform.rotation = Quaternion.Euler(0f, 0f, 0f); // Remove any rotation
        Bounds roomBounds = new Bounds(this.transform.position, this.transform.localScale); // Create a new Bounding Box centered on the objects position & the scale of the parent object

        foreach (Renderer renderer in GetComponentsInChildren<Renderer>()) // For every child GameObject of this Game Object, find a Renderer
        {
            roomBounds.Encapsulate(renderer.bounds);  // Make the bounds include the local bounds of the renderer
        }
        Vector3 localCenter = roomBounds.center - this.transform.position; // Return a new center point that is the center of the new bounds, minus the transform of the original object
        roomBounds.center = localCenter; // Assign this new center point to the variable "localCenter"
        Debug.Log("The local bounds of this model is " + roomBounds);
        this.transform.rotation = currentRotation;

        return roomBounds; // returns the new encapsulated bounds

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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(RoomBounds.center, RoomBounds.size);
    }
}
      

