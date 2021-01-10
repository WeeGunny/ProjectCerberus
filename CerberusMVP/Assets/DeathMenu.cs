﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    private void Start() {
        rbCam.UnlockCam();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("HubArea");
        Debug.Log("Loading Game...");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting Game...");
    }
}
