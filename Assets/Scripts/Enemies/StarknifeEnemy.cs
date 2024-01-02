using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarknifeEnemy : Enemy
{
    private Transform player;

    void Start()
    {
        player = GameObject.Find("Player").transform;
        InitHP();
        StartCoroutine(WaitForAttack());
    }


    private void Update()
    {
        if (enemyBulletSpawner.isFiring)
        {
            Fire(true);
        }

        LookAtPlayer();
    }

    private void LookAtPlayer()
    {
        if (enemyBulletSpawner.isFiring)
        {
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward * 5 * Time.deltaTime);
            transform.rotation = rotation;
        }
    }
}
