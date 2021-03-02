using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerArea : MonoBehaviour
{
    int id;
    public Room roomAttachedTo;

    private void Start() {
        id = roomAttachedTo.id;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && roomAttachedTo.roomHasEnemies == true) {
            GameEvents.current.DoorwayTriggerExit(id);
        }
        
    }
}
