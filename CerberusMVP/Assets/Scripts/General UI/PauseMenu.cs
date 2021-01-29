﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{

    public static bool GamePaused = false;

    public GameObject pauseMenuUI;
    public GameObject gameUI;

    //Controller
    PlayerControls controls;

    private void Awake()
    {
        controls = new PlayerControls();
        controls.Gameplay.Pause.performed += ctx => Pause();
        controls.Gameplay.Pause.performed += ctx => Resume();
    }
    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }

    private void Start() {
        pauseMenuUI.gameObject.SetActive(false);
        Resume();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume();
            }

            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        if (!NPC.playerIsTalking) {
            gameUI.SetActive(true);
            rbCam.UnlockCam();
        }
        
        Time.timeScale = 1f;
        GamePaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        gameUI.SetActive(false);
        Time.timeScale = 0f;
        GamePaused = true;
        Debug.Log("Pausing Game");
        if (!NPC.playerIsTalking) rbCam.LockCam();
    }

    public void LoadMenu()
    {
        //if this doesn't work make sure that the menu is in the game's build
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
