using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameplayUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI hitPointText;
    [SerializeField] private TextMeshProUGUI nukeText;
    [SerializeField] private TextMeshProUGUI powerText;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void DisplayedInformation()
    {
        hitPointText.text = GameManager.sharedInstance.hitPoints.value.ToString();
        nukeText.text = GameManager.sharedInstance.nuke.value.ToString();
        scoreText.text = GameManager.sharedInstance.score.value.ToString();
        powerText.text = PlayerBulletManager.instance.BulletLevel.ToString();
    }

    void Update()
    {
        DisplayedInformation();
    }
}
