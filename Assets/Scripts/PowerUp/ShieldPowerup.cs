using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerup : PowerUp
{
    protected override void ActPowerup()
    {
        AudioManager.instance.PlayItemPick();
        Player.instance.PowerupShield();
    }

}
