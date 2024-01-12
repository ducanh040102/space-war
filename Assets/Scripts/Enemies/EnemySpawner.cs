using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance { get; private set; }

    public event EventHandler<OnEnterNewWaveEventArgs> OnEnterNewWave;
    public class OnEnterNewWaveEventArgs : EventArgs
    {
        public string _wave;
        public string _text;
    }

    public List<Transform> enemySpawnedList;

    public int stage = 0;

    [SerializeField] private int wave;

    [SerializeField] private LoadCSV loadCSV;
    [SerializeField] private Transform[] enemyPrefab;
    [SerializeField] private Transform[] bossPrefab;
    [SerializeField] private Transform spawnPosittion;
    [SerializeField] private Transform endInitialPostition;
    
    [SerializeField] private float spawnDelayMax;

    private void Awake()
    {
        Instance = this;
    }

    public void StartSpawn()
    {
        StartCoroutine(NextWave());
    }

    private IEnumerator NextWave()
    {
        string[] data = loadCSV.LoadNewCSV("Wave" + wave);

        if(data != null)
        {
            string[] row = loadCSV.ReadSpawnRow(6);

            OnEnterNewWave?.Invoke(this, new OnEnterNewWaveEventArgs
            {
                _wave = wave.ToString(),
                _text = row[0]
            });

            yield return new WaitForSeconds(5);

            SpawnEnemy();
            while (enemySpawnedList.Count != 0)
            {
                yield return null;
            }


            wave++;
            if (row[1] == "FinalWave")
                StartCoroutine(NextStage());
            else if (row[1] == "End")
                StartCoroutine(EndGame());
            else
                StartCoroutine(NextWave());

        }

        yield return null;
    }

    IEnumerator NextStage()
    {
        stage++;
        yield return new WaitForSeconds(40f);
    }
    
    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(20f);
        Loader.Load(Loader.Scene.MainMenuScene);
    }

    public void SpawnEnemy()
    {
        for (int i = 0; i < 6; i++)
        {
            string[] row = loadCSV.ReadSpawnRow(i);
            for (int j = 0; j < 9; j++)
            {
                Vector3 position = new Vector3(j * 2f + endInitialPostition.position.x, i + endInitialPostition.position.y, 0);

                if (int.Parse(row[j]) == 1)
                {
                    SpawnEnemy(enemyPrefab[0], position);
                }

                if (int.Parse(row[j]) == 2)
                {
                    SpawnEnemy(enemyPrefab[1], position);
                }
                
                if (int.Parse(row[j]) == 3)
                {
                    SpawnEnemy(enemyPrefab[2], position);
                }
                
                if (int.Parse(row[j]) == 11)
                {
                    SpawnEnemy(bossPrefab[0], position);
                }
            }
        }
    }

    private Transform SpawnEnemy(Transform enemyPrefab, Vector3 position)
    {
        Transform enemySpawned = Instantiate(enemyPrefab, spawnPosittion.position, enemyPrefab.transform.rotation);
        enemySpawnedList.Add(enemySpawned);
        enemySpawned.DOMove(position, 2f).SetEase(Ease.InOutSine).OnComplete(() =>
        {
            enemySpawned.GetComponent<Enemy>().StartAction();
        });

        return enemySpawned;
    }

    public void HitAllEnemy(float damage)
    {
        if (enemySpawnedList.Count == 0)
            return;
        foreach (Transform enemy in enemySpawnedList)
        {
            if(enemy != null)
            {
                enemy.GetComponent<Enemy>().Hit(damage);
            }
        }
    }
}
