using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukePowerup : PowerUp
{

    protected override void ActPowerup()
    {
        AudioManager.instance.PlayItemPick();
        GameManager.sharedInstance.IncreNuke();
    }
}
