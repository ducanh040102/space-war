using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletSpawner : Spawner
{
    [SerializeField] private Transform playerFiringPoint;

    private float playerFireCountdown = 0;

    private void Update()
    {
        playerFireCountdown -= Time.deltaTime;
    }

    public void SpawnBullet()
    {
        if (playerFireCountdown <= 0)
        {
            Spawn(playerFiringPoint.transform.position);
            playerFireCountdown = SpawnCountdownMax;
        }
    }
}
