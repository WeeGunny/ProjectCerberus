using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public SceneLoader sceneLoader;

    private void Start() {
        rbCam.LockCam();
    }
    public void PlayGame()
    {
        sceneLoader.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
