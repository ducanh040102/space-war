using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerup : PowerUp
{
    protected override void ActPowerup()
    {
        base.ActPowerup();
        AudioManager.instance.PlayItemPick();
        GameManager.sharedInstance.IncreHitPoints();
    }
}
