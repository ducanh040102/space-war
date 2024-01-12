using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGunPowerup : PowerUp
{
    protected override void ActPowerup()
    {
        base.ActPowerup();
        AudioManager.instance.PlayWeaponUpgrade();

        if (PlayerBulletManager.instance.typeBullet != PlayerBulletManager.TypeOfBullet.MainGun)
            PlayerBulletManager.instance.typeBullet = PlayerBulletManager.TypeOfBullet.MainGun;
        else
            PlayerBulletManager.instance.IncreaseBulletLevel();
    }
}
