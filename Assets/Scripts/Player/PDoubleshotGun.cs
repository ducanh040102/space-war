using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PDoubleshotGun : PGunBase
{
    public static int bulletCounts;

    private void Start()
    {
        bulletCounts = 0;
    }

    public override void FireBullet()
    {

        if (bulletCounts == 1)
        {
            GameObject bullet = SpawnBullet(firingPoint.position);
            return;
        }
        if (bulletCounts == 2)
        {
            GameObject bullet1 = SpawnBullet(firingPoint.position + new Vector3(.5f, 0, 0));
            GameObject bullet2 = SpawnBullet(firingPoint.position + new Vector3(-.5f, 0, 0));
            return;
        }
        if (bulletCounts == 3)
        {
            GameObject bullet1 = SpawnBullet(firingPoint.position + new Vector3(1f, 0, 0));
            GameObject bullet2 = SpawnBullet(firingPoint.position + new Vector3(-1f, 0, 0));
            GameObject bullet3 = SpawnBullet(firingPoint.position);
            return;
        }

        if (bulletCounts == 4)
        {
            GameObject bullet1 = SpawnBullet(firingPoint.position + new Vector3(.5f, 0, 0));
            GameObject bullet2 = SpawnBullet(firingPoint.position + new Vector3(-.5f, 0, 0));
            return;
        }

        if (bulletCounts == 5)
        {
            GameObject bullet1 = SpawnBullet(firingPoint.position + new Vector3(.5f, 0, 0));
            GameObject bullet2 = SpawnBullet(firingPoint.position + new Vector3(-.5f, 0, 0));
            return;
        }

        else if (bulletCounts > 5)
        {
            return;
        }
        
    }
}
