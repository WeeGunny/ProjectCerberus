using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{
    private GameObject winScreen;

    private void Awake()
    {
        winScreen = GameObject.FindGameObjectWithTag("LevelEnd");
    }

    private void OnTriggerEnter(Collider collider)
    {
        //Find Win Screen object and set to active when the player enters the trigger
        if (collider.tag == "Player")
        {
            SceneManager.LoadScene("VictoryScene");
        }
    }
}
