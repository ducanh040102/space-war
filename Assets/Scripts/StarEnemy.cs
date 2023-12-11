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

    private IEnumerator WaitForAttack()
    {
        while (!isStartAction)
        {
            yield return null;
        }
        isSpawningBullet = true;

    }
    private void Update()
    {
        if (isSpawningBullet)
        {
            Fire(true);
        }
    }
}
