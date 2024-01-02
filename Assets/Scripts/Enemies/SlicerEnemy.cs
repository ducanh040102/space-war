using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlicerEnemy : Enemy
{
    void Start()
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
