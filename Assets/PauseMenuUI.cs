using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuUI : MonoBehaviour
{
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button settingButton;
    [SerializeField] private Button toMenuButton;
    [SerializeField] private PauseMenu pauseMenu;
    [SerializeField] private SoundSettingUI soundSettingUI;

    private void Awake()
    {
        resumeButton.onClick.AddListener(() =>
        {
            pauseMenu.resumeGame();
        });

        settingButton.onClick.AddListener(() =>
        {
            soundSettingUI.Show();
        });

        toMenuButton.onClick.AddListener(() =>
        {
            pauseMenu.resumeGame();
            Loader.Load(Loader.Scene.MainMenuScene);
        });
    }


}
