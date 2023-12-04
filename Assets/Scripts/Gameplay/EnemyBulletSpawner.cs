using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletSpawner : Spawner
{
    [SerializeField] private Transform enemyFiringPoint;
    private float enemyFireCountdown = 0;

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
            Spawn(enemyFiringPoint.position);
            enemyFireCountdown = GetSpawnRandomCountdown();
        }
    }
}
