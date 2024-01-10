using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PRocket : MonoBehaviour
{
    public float timer;
    public float damage;

    private void Start()
    {
        StartCoroutine(Explode());
    }


    private IEnumerator Explode()
    {
        yield return new WaitForSeconds(timer);
        foreach (Transform enemy in EnemySpawner.Instance.enemySpawnedList)
        {
            enemy.GetComponent<Enemy>().Hit(damage);
        }
        Destroy(gameObject);
    }

    
}
