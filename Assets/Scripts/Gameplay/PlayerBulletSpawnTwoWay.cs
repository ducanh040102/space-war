using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletSpawnTwoWay : PlayerBulletSpawnDefault
{
    private Vector3 vec = new Vector3(.5f,0,0);
    public override void FireBullet()
    {
        GameObject bullet1 = SpawnBullet(firingPoint.position + vec);
        GameObject bullet2 = SpawnBullet(firingPoint.position + (-vec));
    }
}
