using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private void Start() {
        rbCam.LockCam();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("HubArea");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
