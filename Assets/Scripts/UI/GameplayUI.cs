using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameplayUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI hitPointText;
    [SerializeField] TextMeshProUGUI nukeText;
    [SerializeField] TextMeshProUGUI scoreText;

    private void DisplayedInformation()
    {
        hitPointText.text = GameManager.sharedInstance.hitPoints.value.ToString();
        nukeText.text = GameManager.sharedInstance.nuke.value.ToString();
        scoreText.text = GameManager.sharedInstance.score.value.ToString();
    }

    void Update()
    {
        DisplayedInformation();
    }
}
