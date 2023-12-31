using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI hitPointText;
    [SerializeField] TextMeshProUGUI nukeText;
    [SerializeField] TextMeshProUGUI scoreText;

    public HitPoints hitPoints;
    public int maxHitPoints;
    public Nuke nuke;
    public Score score;

    public int MaxHitPoints { get => maxHitPoints; set => maxHitPoints = value; }

    private void Awake()
    {
        score.value = 0;
        hitPoints.value = MaxHitPoints;
        nuke.value = 0;
    }

    void Start()
    {
        DisplayedInfor();
    }

    private void DisplayedInfor()
    {
        hitPointText.text = hitPoints.value.ToString();
        nukeText.text = nuke.value.ToString();
        scoreText.text = score.value.ToString();
    }

    void Update()
    {
        DisplayedInfor();
    }

    public void UpdateScore(int points)
    {
        score.value += points;
    }

    public void IncreHitPoints()
    {
        hitPoints.value++;
    }

    public void DecreHitPoints()
    {
        hitPoints.value--;
    }

    public int GetHitPoints()
    {
        return hitPoints.value;
    }

    public void IncreNuke()
    {
        nuke.value++;
    }
}
