using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoubleshotGunPowerup : PowerUp
{
    protected override void ActPowerup()
    {
        AudioManager.instance.PlayWeaponUpgrade();

        if (PlayerBulletManager.instance.typeBullet != PlayerBulletManager.TypeOfBullet.DoubleshotGun)
            PlayerBulletManager.instance.typeBullet = PlayerBulletManager.TypeOfBullet.DoubleshotGun;
        else
            PlayerBulletManager.instance.IncreaseBulletLevel();

    }
}
