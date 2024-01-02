using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSettingUI : MonoBehaviour
{

    [SerializeField] private Transform pauseContainer;

    private void Show()
    {
        pauseContainer.gameObject.SetActive(true);
    }

    private void Hide()
    {
        pauseContainer.gameObject.SetActive(false);
    }


    private void Start()
    {
        //optionButton.onClick.AddListener(() =>
        //{
        //    Hide();
        //    OptionUI.Instance.Show(Show);
        //});
    }

}

