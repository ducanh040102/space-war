using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PDoubleshotGun : PGunBase
{
    [SerializeField] private ObjectPool doubleshotUpgradePool;

    public override void FireBullet()
    {

        if (PlayerBulletManager.instance.BulletLevel == 0)
        {
            SpawnObject(spawnPosition.position);
            
        }
        if (PlayerBulletManager.instance.BulletLevel == 1)
        {
            SpawnObject(spawnPosition.position + new Vector3(.2f, 0, 0));
            SpawnObject(spawnPosition.position + new Vector3(-.2f, 0, 0));
        }
        if (PlayerBulletManager.instance.BulletLevel == 2)
        {
            SpawnObject(spawnPosition.position + new Vector3(.3f, 0, 0));
            SpawnObject(spawnPosition.position + new Vector3(-.3f, 0, 0));
            SpawnObject(spawnPosition.position + new Vector3(0, .1f, 0));
        }

        if (PlayerBulletManager.instance.BulletLevel == 3)
        {
            SpawnObject(spawnPosition.position + new Vector3(.3f, 0, 0));
            SpawnObject(spawnPosition.position + new Vector3(-.3f, 0, 0));
            doubleshotUpgradePool.SpawnObject(spawnPosition.position + new Vector3(0, .1f, 0));
        }

        if (PlayerBulletManager.instance.BulletLevel == 4)
        {
            doubleshotUpgradePool.SpawnObject(spawnPosition.position + new Vector3(.2f, 0, 0));
            doubleshotUpgradePool.SpawnObject(spawnPosition.position + new Vector3(-.2f, 0, 0));
        }
        
        if (PlayerBulletManager.instance.BulletLevel == 5)
        {
            doubleshotUpgradePool.SpawnObject(spawnPosition.position + new Vector3(.3f, .1f, 0));
            doubleshotUpgradePool.SpawnObject(spawnPosition.position + new Vector3(-.3f, .1f, 0));
            SpawnObject(spawnPosition.position);
        }
        
        if (PlayerBulletManager.instance.BulletLevel == 6)
        {
            doubleshotUpgradePool.SpawnObject(spawnPosition.position + new Vector3(.3f, .0f, 0));
            doubleshotUpgradePool.SpawnObject(spawnPosition.position + new Vector3(-.3f, .0f, 0));
            doubleshotUpgradePool.SpawnObject(spawnPosition.position + new Vector3(0, .1f, 0));
        }

        if(PlayerBulletManager.instance.BulletLevel == 7)
        {
            doubleshotUpgradePool.SpawnObject(spawnPosition.position + new Vector3(.3f, 0, 0));
            doubleshotUpgradePool.SpawnObject(spawnPosition.position + new Vector3(-.3f, 0, 0));
            doubleshotUpgradePool.SpawnObject(spawnPosition.position + new Vector3(0, .1f, 0));
            SpawnObject(spawnPosition.position + new Vector3(.6f, -.1f, 0));
            SpawnObject(spawnPosition.position + new Vector3(-.6f, -.1f, 0));
        }
        
        if(PlayerBulletManager.instance.BulletLevel == 8)
        {
            doubleshotUpgradePool.SpawnObject(spawnPosition.position + new Vector3(.3f, 0, 0));
            doubleshotUpgradePool.SpawnObject(spawnPosition.position + new Vector3(-.3f, 0, 0));
            doubleshotUpgradePool.SpawnObject(spawnPosition.position + new Vector3(0, .1f, 0));
            doubleshotUpgradePool.SpawnObject(spawnPosition.position + new Vector3(.5f, -.1f, 0));
            doubleshotUpgradePool.SpawnObject(spawnPosition.position + new Vector3(-.5f, -.1f, 0));
        }
        
    }
}
