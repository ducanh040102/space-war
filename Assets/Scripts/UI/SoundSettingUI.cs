using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSettingUI : MonoBehaviour
{

    [SerializeField] private Transform container;

    private void Start()
    {
        Hide();
    }

    public void Show()
    {
        container.gameObject.SetActive(true);
    }

    public void Hide()
    {
        container.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Hide();
        }
    }
}

