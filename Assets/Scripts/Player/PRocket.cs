using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PRocket : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float timer;

    private void Start()
    {
        StartCoroutine(Explode());
    }


    private IEnumerator Explode()
    {
        yield return new WaitForSeconds(timer);
        EnemySpawner.Instance.HitAllEnemy(damage);
        VFXManager.instance.SpawnExplosion(transform.position, Vector3.one * 5, 2, 0.5f);
        AudioManager.instance.PlayBigExplode();
        Destroy(gameObject);
    }

    
}
