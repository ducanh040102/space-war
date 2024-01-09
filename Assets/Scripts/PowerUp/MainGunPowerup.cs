using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGunPowerup : PowerUp
{
    protected override void ActPowerup()
    {
        PMainGun.bulletCounts++;
        PlayerBulletManager.instance.typeBullet = PlayerBulletManager.TypeOfBullet.MainGun;
    }
}
