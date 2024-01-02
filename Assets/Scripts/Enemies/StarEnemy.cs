using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarEnemy : Enemy
{
    private void Start()
    {
        InitStats();
        StartCoroutine(WaitForAttack());
        //gameUIController = GameObject.FindWithTag("GameManager").GetComponent<GameUIController>();
        powerupSpawner = GameObject.FindObjectOfType<PowerupSpawner>();
    }

    private void Update()
    {
        if (enemyBulletSpawner.isFiring)
        {
            Fire(true);
        }
    }
}
