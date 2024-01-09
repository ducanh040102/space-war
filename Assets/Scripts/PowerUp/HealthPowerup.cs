using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerup : PowerUp
{
    [SerializeField] private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

    }

    protected override void ActPowerup()
    {
        if (gameManager.GetHitPointsValue() < gameManager.MaxHitPoints)
        {
            gameManager.IncreHitPoints();

        }
    }
}
