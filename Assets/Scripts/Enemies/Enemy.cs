using DG.Tweening;
using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float hitPointMax = 50;
    [SerializeField] private float hitPoint;
    [SerializeField] private bool isStartAction = false;

    protected EnemyBulletSpawner enemyBulletSpawner;
    private PowerupSpawner powerupSpawner;

    public bool IsStartAction { get => isStartAction; private set => isStartAction = value; }
    public float HitPoint { get => hitPoint; private set => hitPoint = value; }
    public float HitPointMax { get => hitPointMax; private set => hitPointMax = value; }

    private void Start()
    {
        InitialStats();
        StartCoroutine(WaitForAttack());
    }

    private void Update()
    {
        Fire();
        Destroy();
    }

    protected virtual void InitialStats()
    {
        powerupSpawner = PowerupSpawner.sharedInstance;
        enemyBulletSpawner = gameObject.GetComponent<EnemyBulletSpawner>();

        HitPoint = HitPointMax;
    }

    protected virtual void Fire()
    {
        enemyBulletSpawner.SpawnBullet();
    }

    public void Hit(float damage)
    {
        if (IsStartAction)
        {
            HitPoint -= damage;
        }
    }

    protected virtual void Destroy()
    {
        if(HitPoint <= 0)
        {
            transform.DOKill();
            powerupSpawner.SpawnPowerup(transform);
            enemyBulletSpawner.StopFiring();

            EnemySpawner.Instance.enemySpawnedList.Remove(transform);
            VFXManager.instance.SpawnExplosion(transform.position, Vector3.one, 1);

            Destroy(gameObject);
        }
        
    }

    protected virtual IEnumerator WaitForAttack()
    {
        while (!IsStartAction)
        {
            yield return null;
        }
        enemyBulletSpawner.StartFiring();
    }

    public void StartAction()
    {
        IsStartAction = true;
    }
}
