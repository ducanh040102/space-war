using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPowerup : PowerUp
{
    protected override void ActPowerup()
    {
        AudioManager.instance.PlayWeaponUpgrade();

        if (PlayerBulletManager.instance.typeBullet != PlayerBulletManager.TypeOfBullet.Laser)
            PlayerBulletManager.instance.typeBullet = PlayerBulletManager.TypeOfBullet.Laser;
        else
            PlayerBulletManager.instance.bulletLevel++;
    }

}
