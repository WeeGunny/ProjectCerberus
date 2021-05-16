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
        SceneManager.LoadScene(2);
        
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadNarrative()
    {
        SceneManager.LoadScene(5);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
