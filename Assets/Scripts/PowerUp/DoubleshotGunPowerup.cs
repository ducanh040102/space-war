using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoubleshotGunPowerup : PowerUp
{
    protected override void ActPowerup()
    {
        PlayerBulletManager.instance.typeBullet = PlayerBulletManager.TypeOfBullet.DoubleshotGun;
        PDoubleshotGun.bulletCounts++;

    }
}
