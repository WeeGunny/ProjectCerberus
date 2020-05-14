using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject playerPrefab;
    public Transform spawnPoint;
    GameObject player;

    void Start()
    {
        player = Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
