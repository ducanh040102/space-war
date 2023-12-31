using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Player;

public class DoubleshotGunPowerup : PowerUp
{
    protected override void ActPowerup()
    {
        PDoubleshotGun.bulletCounts++;
        Player.typeBullet = TypeOfBullet.DoubleshotGun;
    }
}
