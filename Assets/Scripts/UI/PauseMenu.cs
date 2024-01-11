using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public static bool isPaused;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                resumeGame();
            }
            else
            {
                pauseGame();
            }

        }
    }

    public void pauseGame()
    {
        pauseMenuUI.GetComponent<PauseMenuUI>().Show();
        Time.timeScale = 0f;
        audioManager.PlaySFX(audioManager.pause);
        isPaused = true;
    }

    public void resumeGame()
    {
        pauseMenuUI.GetComponent<PauseMenuUI>().Hide();
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void GoToMainMenu() { 
        Time.timeScale = 1f;
        Loader.Load(Loader.Scene.MainMenuScene);
    }
}

