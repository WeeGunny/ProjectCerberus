using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public int id;
    public Room room;
    
    // Start is called before the first frame update
    private void Start()
    {
        GameEvents.current.onDoorwayTriggerExit += OnDoorwayClose;
        GameEvents.current.onEnemiesDefeated += OnEnemiesDefeated;

        this.gameObject.SetActive(false);
    }
    
    public void OnDoorwayClose(int id)
    {
        if (id == this.id)
        {
            this.gameObject.SetActive(true);
            room.SpawnEnemies();
        }
            
    }

    public void OnEnemiesDefeated(int id)
    {
        if (room.enemySPs.Count == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        GameEvents.current.onDoorwayTriggerExit -= OnDoorwayClose;
        GameEvents.current.onEnemiesDefeated -= OnEnemiesDefeated;
    }
}
