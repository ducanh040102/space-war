using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletSpawner : Spawner
{
    [SerializeField] private Transform enemyFiringPoint;
    [SerializeField] private FiringPattern firingPattern;
    private float enemyFireCountdown = 0;

    public enum FiringPattern
    {
        StraightDownPattern,
        ThreeShotPattern,
        StarPattern
    }

    private void Start()
    {
        enemyFireCountdown = GetSpawnRandomCountdown();
    }

    private void Update()
    {
        enemyFireCountdown -= Time.deltaTime;
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
                case FiringPattern .ThreeShotPattern:
                    ThreeShot();
                    break;

            }
            
            enemyFireCountdown = GetSpawnRandomCountdown();
        }
    }

    private void StraightDown()
    {
        Spawn(enemyFiringPoint.position);
    }

    private void ThreeShot()
    {
        Spawn(enemyFiringPoint.position);
        Transform left = Spawn(enemyFiringPoint.position + Vector3.left);
        Transform right = Spawn(enemyFiringPoint.position + Vector3.right);

        left.GetComponent<ObjectMoveInScene>().move = ObjectMoveInScene.Move.DownLeft;
        right.GetComponent<ObjectMoveInScene>().move = ObjectMoveInScene.Move.DownRight;
    }
}
