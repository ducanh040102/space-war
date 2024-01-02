using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletSpawner : Spawner
{
    [SerializeField] private Transform playerFiringPoint;
    
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private float playerFireCountdown = 0;

    private void Update()
    {
        playerFireCountdown -= Time.deltaTime;
    }

    public void SpawnBullet()
    {
        if (playerFireCountdown <= 0)
        {
            audioManager.PlaySFX(audioManager.playerShoot);
            Spawn(playerFiringPoint.transform.position);
            playerFireCountdown = SpawnCountdownMax;
        }
    }
}
