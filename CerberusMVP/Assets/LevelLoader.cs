using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public string LevelToLoad;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            SceneManager.LoadScene(LevelToLoad);
            Debug.Log("Loading level!");
        }
    }
}
