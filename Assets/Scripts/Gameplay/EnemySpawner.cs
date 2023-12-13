using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;
using Sequence = DG.Tweening.Sequence;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance { get; private set; }

    public List<Transform> enemySpawnedList;

    [SerializeField] private LoadCSV loadCSV;
    [SerializeField] private Transform enemyPrefab;
    [SerializeField] private Transform clawBossPrefab;
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
        await Task.Delay(5000);

        LoadCSVAndSpawnEnemy(3);

        while (!(enemySpawnedList.Count == 0))
        {
            await Task.Delay(1000);
        }

        Wave2();
    }

    private async void Wave2() 
    {
        await Task.Delay(5000);

        LoadCSVAndSpawnEnemy(2);

        while (!(enemySpawnedList.Count == 0))
        {
            await Task.Delay(1000);
        }

        BossFight();
    }

    private async void BossFight()
    {
        await Task.Delay(5000);
        LoadCSVAndSpawnEnemy(3);
    }

    public void LoadCSVAndSpawnEnemy(int number)
    {

        loadCSV.LoadNewCSV(number);
        for (int i = 0; i < 6; i++)
        {
            string[] row = loadCSV.ReadSpawnRow(i);
            for (int j = 0; j < 9; j++)
            {
                Vector3 position = new Vector3(j * 2f + endInitialPostition.position.x, i + endInitialPostition.position.y, 0);

                if (int.Parse(row[j]) == 1)
                {
                    SpawnEnemy(enemyPrefab, position);
                }

                if (int.Parse(row[j]) == 2)
                {
                    SpawnEnemy(clawBossPrefab, position);
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
}
