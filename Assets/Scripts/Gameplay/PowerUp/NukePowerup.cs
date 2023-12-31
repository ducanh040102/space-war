using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukePowerup : PowerUp
{
    [SerializeField] private GameUIController gameUIController;

    private void Start()
    {
        gameUIController = GameObject.FindWithTag("GameManager").GetComponent<GameUIController>();

    }

    protected override void ActPowerup()
    {
        gameUIController.IncreNuke();
    }
}
