using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerup : PowerUp
{
    [SerializeField] private float shieldDuration = 3f;

    protected override void ActPowerup()
    {
        base.ActPowerup();
        AudioManager.instance.PlayItemPick();
        Player.instance.PowerupShield(shieldDuration);
    }

}
