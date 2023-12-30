using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerBulletSpawnTwoWay : PBulletSpawner
{
    public static int bulletCounts ;

    private void Start()
    {
        bulletCounts = 0;
    }

    float Angle;

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
        if (bulletCounts >= 3)
        {
            Angle = -15f;
            Vector3 vec = new Vector3(0, 0, Angle);
            for (int i = 0; i < bulletCounts; i++)
            {

                GameObject bullet = SpawnBullet(firingPoint.position);
                bullet.transform.rotation = Quaternion.Euler(vec);
                vec.z += 2 * Mathf.Abs(Angle) / (bulletCounts - 1);
            }
        }
        else if (bulletCounts > 5)
        {
            return;
        }
        
    }
}
