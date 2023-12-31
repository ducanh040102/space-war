using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Player;

public class MainGunPowerup : PowerUp
{
    protected override void ActPowerup()
    {
        PMainGun.bulletCounts++;
        Player.typeBullet = TypeOfBullet.MainGun;
    }
}
