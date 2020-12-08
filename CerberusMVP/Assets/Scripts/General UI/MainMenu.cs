using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        //SceneManager.LoadScene("Main");
        SceneManager.LoadScene("HubArea");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
