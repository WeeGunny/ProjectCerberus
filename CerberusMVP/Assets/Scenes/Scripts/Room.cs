using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Room : MonoBehaviour {
    // Array of available doorways
    public Doorway[] doorways;
    public MeshCollider meshCollider;
    public List<GameObject> spawnPoints, usedSpawnPoints, enemyPrefabs;
    public int numOfEnemies;
    // Get the bounding box of a room
    public Bounds RoomBounds {
        get { return meshCollider.bounds; }
    }

    private void Start() {
        SpawnEnemies();
    }

    public void SpawnEnemies() {

        for (int i = 0; i < numOfEnemies; i++) {
            if (spawnPoints.Count == 0) {
                //if there are no more empty spawn points break
                break;
            }
            int randomEnemy = Random.Range(0, enemyPrefabs.Count);
            int randomSpawnPoint = Random.Range(0, spawnPoints.Count);
            Instantiate(enemyPrefabs[randomEnemy], spawnPoints[randomSpawnPoint].transform);
            //adds spawn point to used spawn points, and removes it as an available spawn point.
            usedSpawnPoints.Add(spawnPoints[randomSpawnPoint]);
            spawnPoints.RemoveAt(randomSpawnPoint);
        }

    }

}
