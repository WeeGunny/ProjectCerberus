using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System;

public class PauseMenu : MonoBehaviour
{

    public static bool GamePaused = false;

    public GameObject pauseMenuUI;
    public GameObject gameUI;
    private bool isPaused = false;

    //Controller
    PlayerControls controls;

    private void Awake()
    {
        controls = new PlayerControls();
        controls.Gameplay.Pause.performed += ctx => pauseInput();
    }

    private void pauseInput() {
        if (!NPC.playerIsTalking) {
            isPaused = !isPaused;
            if (isPaused) {
                Pause();
            }
            else {
                Resume();
            }
        }
        else DialogueManager.dm.StopDialog();
       
        
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

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        gameUI.SetActive(true);
        if(Interacter.instance)if(!Interacter.instance.IsInteracting)rbCam.UnlockCam();
        
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
        if(!rbCam.camLocked)rbCam.LockCam();
    }

    public void LoadMenu()
    {
        //if this doesn't work make sure that the menu is in the game's build
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        PlayerManager.stats.ResetValues();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
