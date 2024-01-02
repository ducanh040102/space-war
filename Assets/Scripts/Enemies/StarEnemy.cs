using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarEnemy : Enemy
{
    private void Start()
    {
        InitHP();
        StartCoroutine(WaitForAttack());
    }

    private void Update()
    {
        if (enemyBulletSpawner.isFiring)
        {
            Fire(true);
        }
    }
}
