using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarknifeEnemy : Enemy
{
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        InitStats();
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
        if (enemyBulletSpawner.isFiring && player != null)
        {
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward * 5 * Time.deltaTime);
            transform.rotation = rotation;
        }
    }
}
