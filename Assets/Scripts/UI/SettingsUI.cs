using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    [SerializeField] private Button musicButton;
    [SerializeField] private Button sfxButton;
    [SerializeField] private Button difficultButton;
    [SerializeField] private Button rocketBindingButton;
    [SerializeField] private Button fireBindingButton;
    [SerializeField] private Button moveUpBindingButton;
    [SerializeField] private Button moveDownBindingButton;
    [SerializeField] private Button moveLeftBindingButton;
    [SerializeField] private Button moveRightBindingButton;
    [SerializeField] private Button backButton;

    private void Awake()
    {
        backButton.onClick.AddListener(() =>
        {
            Loader.LoadWithoutLoading(Loader.Scene.MainMenuScene);
        });
    }
}
