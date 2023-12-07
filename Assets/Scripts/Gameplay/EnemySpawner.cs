using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Sequence = DG.Tweening.Sequence;

public class EnemySpawner : MonoBehaviour
{
    const float stepx = 1f;
    const float stepy = 1f;

    public static EnemySpawner Instance { get; private set; }

    public List<Transform> enemySpawnedList;

    [SerializeField] private LoadCSV loadCSV;
    [SerializeField] private Transform enemyPrefab;
    [SerializeField] private Transform spawnPosittion;
    [SerializeField] private Transform endInitialPostition;
    
    [SerializeField] private float spawnDelayMax;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Wave1();
    }

    private async void Wave1()
    {
        loadCSV.LoadNewCSV(1);

        ReadCSVAndSpawnEnemy();

        while (!(enemySpawnedList.Count == 0))
        {
            await Task.Delay(1000);
        }

        Wave2();
    }

    private async void Wave2() 
    {
        loadCSV.LoadNewCSV(2);

        ReadCSVAndSpawnEnemy();

        while (!(enemySpawnedList.Count == 0))
        {
            await Task.Delay(1000);
        }

        Wave2();
    }

    private void ReadCSVAndSpawnEnemy()
    {
        for (int i = 0; i < 6; i++)
        {
            string[] row = loadCSV.ReadSpawnRow(i);
            for (int j = 0; j < 9; j++)
            {
                Vector3 position = new Vector3(j * 2f + endInitialPostition.position.x, i + endInitialPostition.position.y, 0);

                if (int.Parse(row[j]) == 1)
                {
                    Transform enemySpawned = Instantiate(enemyPrefab, spawnPosittion.position, enemyPrefab.transform.rotation);
                    enemySpawnedList.Add(enemySpawned);
                    enemySpawned.DOMove(position, 0.5f).SetEase(Ease.InOutSine);
                }
            }
        }
    }
}
