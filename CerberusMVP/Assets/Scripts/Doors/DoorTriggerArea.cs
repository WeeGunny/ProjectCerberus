using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerArea : MonoBehaviour
{
    public int id;
    
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") {
            GameEvents.current.DoorwayTriggerExit(id);
        }
        
    }
}
