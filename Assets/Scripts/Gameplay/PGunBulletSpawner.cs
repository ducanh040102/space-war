using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PGunBulletSpawner : PBulletSpawner
{
    public override void FireBullet()
    {
        GameObject bullet = SpawnBullet(firingPoint.position);
    }


}
