using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance { get; private set; }

    public List<Transform> enemySpawnedList;

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

    private void Start()
    {
        StartCoroutine(NextWave());
        
    }

    private IEnumerator NextWave()
    {
        yield return new WaitForSeconds(5);

        LoadCSVAndSpawnEnemy(wave);
        while (enemySpawnedList.Count != 0)
        {
            yield return null;
        }

        wave++;
        StartCoroutine(NextWave());
    }



    public void LoadCSVAndSpawnEnemy(int number)
    {
        if (loadCSV.IsDataNull(number)){
            return;
        }
        loadCSV.LoadNewCSV();
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

    
}
