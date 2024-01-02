using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyBulletSpawner : Spawner
{
    [SerializeField] private Transform enemyFiringPoint;
    [SerializeField] private FiringPattern firingPattern;

    [SerializeField] private int laserDuration;

    private float enemyFireCountdown = 0;
    public bool isFiring = false;
    private Transform laserBullet;

    public enum FiringPattern
    {
        StraightDownPattern,
        ThreeShotPattern,
        StarPattern,
        HommingPattern,
        StraightDownLaser
    }

    private void Start()
    {
        enemyFireCountdown = GetSpawnRandomCountdown();
    }

    private void Update()
    {
        if(isFiring)
        {
            enemyFireCountdown -= Time.deltaTime;
        }
        
    }

    public void SpawnBullet()
    {
        if (enemyFireCountdown <= 0)
        {
            switch (firingPattern)
            {
                case FiringPattern.StraightDownPattern:
                    StraightDown();
                    break;
                case FiringPattern.ThreeShotPattern:
                    ThreeShot();
                    break;
                case FiringPattern.HommingPattern:
                    Homming();
                    break;
                case FiringPattern.StraightDownLaser:
                    Laser();
                    break;
            }
        }
    }

    private void StraightDown()
    {
        Spawn(enemyFiringPoint.position);
        enemyFireCountdown = GetSpawnRandomCountdown();
    }

    private void ThreeShot()
    {
        Spawn(enemyFiringPoint.position);
        Transform leftBullet = Spawn(enemyFiringPoint.position + Vector3.left);
        Transform rightBullet = Spawn(enemyFiringPoint.position + Vector3.right);

        leftBullet.GetComponent<ObjectMoveInScene>().move = ObjectMoveInScene.Move.DownLeft;
        rightBullet.GetComponent<ObjectMoveInScene>().move = ObjectMoveInScene.Move.DownRight;

        enemyFireCountdown = GetSpawnRandomCountdown();
    }
    
    private void Homming()
    {
        Transform bullet = Spawn(enemyFiringPoint.position);

        bullet.GetComponent<ObjectMoveInScene>().move = ObjectMoveInScene.Move.FlyToPlayer;

        enemyFireCountdown = GetSpawnRandomCountdown();
    }

    private async void Laser()
    {
        
        if(laserBullet == null)
        {
            laserBullet = Spawn(enemyFiringPoint.position);
        }
            
        
        if(laserBullet != null)
        {
            EnemyLaser laser = laserBullet.GetComponent<EnemyLaser>();
            laser.EnableLaser();
            await Task.Delay(laserDuration * 1000);
            laser.DisableLaser();
            enemyFireCountdown = GetSpawnRandomCountdown();
        }

        
    }
}
