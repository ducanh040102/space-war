using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform enemyFiringPoint;
    [SerializeField] private Transform enemyBullet;
    [SerializeField] private float enemyFireCountdownMin = 0;
    [SerializeField] private float enemyFireCountdownMax = 0;
    [SerializeField] private float hitPoint = 50;

    private float enemyFireCountdown = 0;


    private void Start()
    {
        ResetFiringRate();
    }

    private void Update()
    {
        Fire();
        GotDestroy();
        enemyFireCountdown -= Time.deltaTime;
    }

    private void Fire()
    {
        if (enemyFireCountdown <= 0)
        {
            SpawnBullet();
            ResetFiringRate();
        }
    }

    private void SpawnBullet()
    {
        Instantiate(enemyBullet, enemyFiringPoint.transform.position, enemyBullet.transform.rotation);
    }

    private void ResetFiringRate()
    {
        enemyFireCountdown = Random.Range(enemyFireCountdownMin, enemyFireCountdownMax);
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
}
