using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float hitPoint = 50;
    [SerializeField] private EnemyBulletSpawner enemyBulletSpawner;

    private void Update()
    {
        Fire();
        GotDestroy();
    }

    private void GotDestroy()
    {
        if(hitPoint <= 0)
            Destroy(gameObject);
    }

    public void GotHit()
    {
        hitPoint -= 1;
    }

    private void Fire()
    {
        enemyBulletSpawner.SpawnBullet();
    }
}
