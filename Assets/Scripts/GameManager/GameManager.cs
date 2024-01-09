using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public HitPoints hitPoints;
    public int maxHitPoints;
    public Nuke nuke;
    public Score score;

    public static GameManager sharedInstance = null;

    public int MaxHitPoints { get => maxHitPoints; set => maxHitPoints = value; }

    private void Awake()
    {
        if (sharedInstance != null && sharedInstance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            sharedInstance = this;
        }

        score.value = 0;
        hitPoints.value = MaxHitPoints;
        nuke.value = 0;
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

    public int GetHitPointsValue()
    {
        return hitPoints.value;
    }

    public int GetNukeValue()
    {
        return nuke.value;
    }

    public void IncreNuke()
    {
        nuke.value++;
    }

    public void DecreNuke()
    {
        nuke.value--;
    }


}
