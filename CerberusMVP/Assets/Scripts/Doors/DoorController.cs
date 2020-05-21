using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public int id;
    
    // Start is called before the first frame update
    private void Start()
    {
        GameEvents.current.onDoorwayTriggerExit += OnDoorwayClose;
        GameEvents.current.onEnemiesDefeated += OnEnemiesDefeated;

        this.gameObject.SetActive(false);
    }
    
    private void OnDoorwayClose(int id)
    {
        if (id == this.id)
        {
            this.gameObject.SetActive(true);
        }
            
    }

    private void OnEnemiesDefeated(int id)
    {
        if (id == this.id)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        GameEvents.current.onDoorwayTriggerExit -= OnDoorwayClose;
        GameEvents.current.onEnemiesDefeated -= OnEnemiesDefeated;
    }
}
