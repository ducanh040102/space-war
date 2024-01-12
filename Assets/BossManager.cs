using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    public static BossManager instance;

    public event EventHandler OnBossDestroy;

    private void Awake()
    {
        instance = this;
    }

    public void BossSpawn()
    {
        AudioManager.instance.PlayBossTheme();
    }

    public void BossDestroy(Vector3 explosionPos)
    {
        EnemySpawner.Instance.HitAllEnemy(10000f);
        VFXManager.instance.SpawnExplosion(explosionPos, Vector3.one * 10, 2, 0.2f);

        AudioManager.instance.PlayBigExplode();
        AudioManager.instance.PlayVictoryTheme();

        OnBossDestroy?.Invoke(this, EventArgs.Empty);
    }

    public void BossSpawnHelper(string helperDataName)
    {
        LoadCSV.instance.LoadNewCSV(helperDataName);
        EnemySpawner.Instance.SpawnEnemy();
    }
}
