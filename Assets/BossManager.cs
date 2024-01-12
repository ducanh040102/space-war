using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    public static BossManager instance;

    public event EventHandler OnBossSpawn;
    public event EventHandler<OnBossDamagedEventArgs> OnBossDamaged;
    public event EventHandler OnBossDestroy;

    public class OnBossDamagedEventArgs : EventArgs
    {
        public float _bossMaxHP;
        public float _bossHP;
    }

    [SerializeField] private float bossHP;
    [SerializeField] private float bossMaxHP;

    private void Awake()
    {
        instance = this;
    }

    public void BossSpawn()
    {
        AudioManager.instance.PlayBossTheme();
        OnBossSpawn?.Invoke(this, EventArgs.Empty);
        bossMaxHP = bossHP;
    }

    public void BossDestroy(Vector3 explosionPos)
    {
        EnemySpawner.Instance.HitAllEnemy(10000f);
        VFXManager.instance.SpawnExplosion(explosionPos, Vector3.one * 10, 2, 0.2f);

        AudioManager.instance.PlayBigExplode();
        AudioManager.instance.PlayVictoryTheme();

        OnBossDestroy?.Invoke(this, EventArgs.Empty);
    }

    public void UpdateBossHp(float hp)
    {
        if (hp < bossHP)
        {
            OnBossDamaged?.Invoke(this, new OnBossDamagedEventArgs{
                _bossMaxHP = bossMaxHP,
                _bossHP = hp
            });
        }
        bossHP = hp;
    }

    public void BossSpawnHelper(string helperDataName)
    {
        LoadCSV.instance.LoadNewCSV(helperDataName);
        EnemySpawner.Instance.SpawnEnemy();
    }
}
