using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
<<<<<<< HEAD:CerberusMVP/Assets/Scripts/General UI/MainMenu.cs
        SceneManager.LoadScene("Main");
=======
        SceneManager.LoadScene("HubArea");
>>>>>>> Enemies:CerberusMVP/Assets/Scripts/MainMenu.cs
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
