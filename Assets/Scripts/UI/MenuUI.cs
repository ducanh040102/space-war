using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private Button newgameButton;
    [SerializeField] private Button continueButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button leaderboardButton;
    [SerializeField] private Button quitButton;

    private void Awake()
    {
        newgameButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.GameplayScene);
        });

        settingsButton.onClick.AddListener(() =>
        {
            Loader.LoadWithoutLoading(Loader.Scene.SettingsScene);
        });

        leaderboardButton.onClick.AddListener(() =>
        {
            Loader.LoadWithoutLoading(Loader.Scene.LeaderboardScene);
        });

        quitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }

}
