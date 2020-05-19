using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public int id;
    
    // Start is called before the first frame update
    private void Start()
    {
        GameEvents.current.onDoorwayTriggerEnter += OnDoorwayOpen;
        GameEvents.current.onDoorwayTriggerExit += OnDoorwayClose;

        this.gameObject.SetActive(true);
    }

    private void OnDoorwayOpen(int id)
    {
        
        if (id == this.id)
        {
            this.gameObject.SetActive(false);
        }
    }
    
    private void OnDoorwayClose(int id)
    {
        if (id == this.id)
        {
            this.gameObject.SetActive(true);
        }
            
    }
}
