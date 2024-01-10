using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PDoubleshotGun : PGunBase
{

    public override void FireBullet()
    {

        if (PlayerBulletManager.instance.bulletLevel == 0)
        {
            GameObject bullet = SpawnObject(spawnPosition.position);
            return;
        }
        if (PlayerBulletManager.instance.bulletLevel == 1)
        {
            GameObject bullet1 = SpawnObject(spawnPosition.position + new Vector3(.2f, 0, 0));
            GameObject bullet2 = SpawnObject(spawnPosition.position + new Vector3(-.2f, 0, 0));
            return;
        }
        if (PlayerBulletManager.instance.bulletLevel == 2)
        {
            GameObject bullet1 = SpawnObject(spawnPosition.position + new Vector3(.3f, 0, 0));
            GameObject bullet2 = SpawnObject(spawnPosition  .position + new Vector3(-.3f, 0, 0));
            GameObject bullet3 = SpawnObject(spawnPosition.position + new Vector3(0, .1f, 0));
            return;
        }

        if (PlayerBulletManager.instance.bulletLevel == 3)
        {
            GameObject bullet1 = SpawnObject(spawnPosition.position + new Vector3(.2f, .1f, 0));
            GameObject bullet2 = SpawnObject(spawnPosition.position + new Vector3(-.2f, .1f, 0));
            GameObject bullet3 = SpawnObject(spawnPosition.position + new Vector3(.4f, 0, 0));
            GameObject bullet4 = SpawnObject(spawnPosition.position + new Vector3(-.4f, 0, 0));
            return;
        }

        if (PlayerBulletManager.instance.bulletLevel > 3)
        {
            GameObject bullet1 = SpawnObject(spawnPosition.position + new Vector3(.3f, .1f, 0));
            GameObject bullet2 = SpawnObject(spawnPosition.position + new Vector3(-.3f, .1f, 0));
            GameObject bullet3 = SpawnObject(spawnPosition.position + new Vector3(0, .2f, 0));
            GameObject bullet4 = SpawnObject(spawnPosition.position + new Vector3(.5f, 0, 0));
            GameObject bullet5 = SpawnObject(spawnPosition.position + new Vector3(-.5f, 0, 0));
            return;
        }
        
    }
}
