using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using Transform = UnityEngine.Transform;

public class LoopingBackground : MonoBehaviour
{
    [SerializeField] private Sprite[] backgroundType;
    [SerializeField] private Transform[] backgroundPieces;
    [SerializeField] private float scrollSpeed = 0.5f;
    [SerializeField] private float warpSpeed = 100f;
    [SerializeField] private float normalSpeed = 5f;

    private Vector3 startPos;
    private float repeatWidth;

    private void Start()
    {
        WarpIn();

        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider2D>().size.y * 0.5f;

        BossManager.instance.OnBossDestroy += Instance_OnBossDestroy;
    }

    private void Instance_OnBossDestroy(object sender, System.EventArgs e)
    {
        WarpOut();
    }

    void Update()
    {
        ScrollAndReset();
    }

    private void ScrollAndReset()
    {
        if (transform.position.y < startPos.y - repeatWidth - 1)
            transform.position = startPos;

        transform.position += Time.deltaTime * scrollSpeed * Vector3.down;
    }

    private void WarpOut()
    {
        DOVirtual.Float(normalSpeed, warpSpeed, 20f, v =>
        {
            scrollSpeed = v;
        }).SetEase(Ease.OutCubic).OnComplete(() =>
        {
            GameplayUI.instance.SceneFadeIn();
            
            StartCoroutine(WaitForWarpIn());
        });
    }
    
    private void WarpIn()
    {
        GameplayUI.instance.SceneFadeOut();
        ChangeBG();
        DOVirtual.Float(warpSpeed, normalSpeed, 10f, v =>
        {
            scrollSpeed = v;
        }).SetEase(Ease.OutCubic).OnComplete(() =>
        {
            EnemySpawner.Instance.StartSpawn();
            AudioManager.instance.PlayBG(EnemySpawner.Instance.stage);
        });
    }

    IEnumerator WaitForWarpIn()
    {
        yield return new WaitForSeconds(10f);
        WarpIn();
    }

    private void ChangeBG()
    {
        int type = EnemySpawner.Instance.stage;

        if(type >= backgroundType.Length)
            type = backgroundType.Length - 1;

        foreach (var bg in backgroundPieces)
        {
            bg.GetComponent<SpriteRenderer>().sprite = backgroundType[type];
        }
    }
}
