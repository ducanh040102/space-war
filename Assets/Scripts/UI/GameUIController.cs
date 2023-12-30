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
    public Nuke nuke;
    public Score score;
    // Start is called before the first frame update

    private void Awake()
    {
        score.value = 0;
    }

    void Start()
    {
        hitPoints.value = 5;
        nuke.value = 0;
        hitPointText.text = hitPoints.value.ToString();
        nukeText.text = nuke.value.ToString();
        scoreText.text = score.value.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        hitPointText.text = hitPoints.value.ToString();
        nukeText.text = nuke.value.ToString();
        scoreText.text = score.value.ToString();

    }

    public void UpdateScore(int points)
    {
        score.value += points;
        //scoreText.text = score.value.ToString();

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
