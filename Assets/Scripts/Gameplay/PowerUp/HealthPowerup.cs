using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerup : PowerUp
{
    [SerializeField] private GameUIController gameUIController;

    private void Start()
    {
        gameUIController = GameObject.FindWithTag("GameManager").GetComponent<GameUIController>();

    }

    protected override void ActPowerup()
    {
        if (gameUIController.GetHitPoints() < gameUIController.MaxHitPoints)
        {
            gameUIController.IncreHitPoints();

        }
    }
}
