using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private Button newgameButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button quitButton;

    [SerializeField] private SoundSettingUI soundsetting;

    [SerializeField] private AudioSource uiSoundEffect;

    private void Awake()
    {
        newgameButton.onClick.AddListener(() =>
        {
            uiSoundEffect.Play();
            Loader.Load(Loader.Scene.DialogueScene);
        });

        settingsButton.onClick.AddListener(() =>
        {
            uiSoundEffect.Play();
            Debug.Log("Setting");
            soundsetting.Show();
        });


        quitButton.onClick.AddListener(() =>
        {
            uiSoundEffect.Play();
            Application.Quit();
        });
    }

}
