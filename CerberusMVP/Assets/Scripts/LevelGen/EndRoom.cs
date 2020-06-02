using UnityEngine;

public class EndRoom : Room
{
    public GameObject bossPrefab;
    public Transform bossSpawnPoint;
    private void Start() {
        Instantiate(bossPrefab, bossSpawnPoint.position, Quaternion.identity);
    }
}