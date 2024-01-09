using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukePowerup : PowerUp
{
    [SerializeField] private GameManager GameManager;

    private void Start()
    {
        GameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

    }

    protected override void ActPowerup()
    {
        GameManager.IncreNuke();
    }
}
