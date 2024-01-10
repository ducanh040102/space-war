using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerup : PowerUp
{
    protected override void ActPowerup()
    {
        AudioManager.instance.PlayItemPick();
        GameManager.sharedInstance.IncreHitPoints();
    }
}
