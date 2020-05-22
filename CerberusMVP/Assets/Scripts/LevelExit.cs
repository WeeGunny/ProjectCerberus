using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    public static bool CanExit = false;
    // Start is called before the first frame update
    void Start()
    {
        CanExit = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player" && CanExit) {

            SceneManager.LoadScene("Level2");
        }
    }
}
