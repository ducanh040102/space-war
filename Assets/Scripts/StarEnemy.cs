using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarEnemy : Enemy
{
    private void Start()
    {
        InitHP();
        StartCoroutine(WaitForAttack());
        gameUIController = GameObject.FindWithTag("GameManager").GetComponent<GameUIController>();
        powerupSpawner = GameObject.FindObjectOfType<PowerupSpawner>();
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
