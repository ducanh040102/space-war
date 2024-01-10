using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMainGun : PGunBase
{

    float Angle;

    public override void FireBullet()
    {
        if (PlayerBulletManager.instance.bulletLevel == 0)
        {
            GameObject bullet = SpawnObject(spawnPosition.position);
            return;
        }
        if (PlayerBulletManager.instance.bulletLevel == 1)
        {
            GameObject bullet1 = SpawnObject(spawnPosition.position + new Vector3(.4f, 0, 0));
            GameObject bullet2 = SpawnObject(spawnPosition.position + new Vector3(-.4f, 0, 0));
            return;
        }

        if (PlayerBulletManager.instance.bulletLevel > 1)
        {
            Angle = -15f;
            Vector3 vec = new Vector3(0, 0, Angle);
            for (int i = 0; i < PlayerBulletManager.instance.bulletLevel; i++)
            {
                GameObject bullet = SpawnObject(spawnPosition.position);
                bullet.transform.rotation = Quaternion.Euler(vec);
                vec.z += 2 * Mathf.Abs(Angle) / (PlayerBulletManager.instance.bulletLevel - 1);
            }
        }

    }
}
