using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    //private GameObject winScreen;

    //private void Awake()
    //{
    //    winScreen = GameObject.FindGameObjectWithTag("LevelEnd");
    //}

    private void OnTriggerEnter(Collider collider)
    {
        //Find Win Screen object and set to active when the player enters the trigger
        GameObject.FindGameObjectWithTag("LevelEnd").SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void OnTriggerExit(Collider collider)
    {
        GameObject.FindGameObjectWithTag("LevelEnd").SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
