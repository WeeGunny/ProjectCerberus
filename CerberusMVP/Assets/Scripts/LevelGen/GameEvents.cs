using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake()
    {
        current = this;
    }

    public event Action<int> onDoorwayTriggerExit;
    public void DoorwayTriggerExit(int id)
    {
        onDoorwayTriggerExit?.Invoke(id);
    }

    public event Action<int> onEnemiesDefeated;
    public void EnemiesDefeated(int id)
    {
        onEnemiesDefeated?.Invoke(id);
    }

    private Func<List<GameObject>> onRequestListofDoors;
    public void SetOnRequestListOfDoors(Func<List<GameObject>> returnEvent)
    {
        onRequestListofDoors = returnEvent;
    }

    public List<GameObject> RequestListOfDoors()
    {
        if (onRequestListofDoors != null)
        {
            return onRequestListofDoors();
        }

        return null;
    }
}
