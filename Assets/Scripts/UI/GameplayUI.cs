using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameplayUI : MonoBehaviour
{

    public static GameplayUI instance;

    [SerializeField] private Transform fadeIn;
    [SerializeField] private Transform fadeOut;

    [SerializeField] private Slider bossHealthBar;
    [SerializeField] private TextMeshProUGUI bossHealthPercent;

    [SerializeField] private TextMeshProUGUI stageNameText;
    [SerializeField] private TextMeshProUGUI hitPointText;
    [SerializeField] private TextMeshProUGUI nukeText;
    [SerializeField] private TextMeshProUGUI powerText;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        EnemySpawner.Instance.OnEnterNewWave += EnemySpawner_OnEnterNewWave;
        BossManager.instance.OnBossSpawn += BossManager_OnBossSpawn;
        BossManager.instance.OnBossDamaged += BossManager_OnBossDamaged;
        BossManager.instance.OnBossDestroy += BossManager_OnBossDestroy;

        bossHealthBar.gameObject.SetActive(false);
    }

    private void BossManager_OnBossDamaged(object sender, BossManager.OnBossDamagedEventArgs e)
    {
        float percent = e._bossHP / e._bossMaxHP;
        bossHealthBar.value = e._bossHP/e._bossMaxHP;
        bossHealthPercent.text = String.Format("{0:0.00}", (percent * 100f)) + "%";
    }

    private void BossManager_OnBossSpawn(object sender, System.EventArgs e)
    {
        bossHealthBar.gameObject.SetActive(true);
        bossHealthBar.value = 1;
        bossHealthPercent.text = "100%";
    }

    private void BossManager_OnBossDestroy(object sender, System.EventArgs e)
    {
        if(bossHealthBar != null)
        {
            bossHealthPercent.text = "0%";
            bossHealthBar.gameObject.SetActive(false);
        }
        
        StageTextTrigger("Stage Clear", "Prepare To Warp");
    }

    private void EnemySpawner_OnEnterNewWave(object sender, EnemySpawner.OnEnterNewWaveEventArgs e)
    {
        StageTextTrigger("Wave " + e._wave, e._text);
    }

    public void StageTextTrigger(string top, string bottom)
    {
        stageNameText.text = top + "\n" + bottom;
        stageNameText.gameObject.SetActive(true);
          
        StartCoroutine(WaitForStageText());
    }

    IEnumerator WaitForStageText()
    {
        yield return new WaitForSeconds(3);
        stageNameText.gameObject.SetActive(false);
    }

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

    public void SceneFadeIn()
    {
        fadeIn.gameObject.SetActive(true);
        fadeOut.gameObject.SetActive(false);
    }
    
    public void SceneFadeOut()
    {
        fadeIn.gameObject.SetActive(false);
        fadeOut.gameObject.SetActive(true);
    }
}
