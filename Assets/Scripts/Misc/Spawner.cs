using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform spawnObjectTransform;
    [SerializeField] private float spawnCountdownMin = 0;
    [SerializeField] private float spawnCountdownMax = 0;

    public float SpawnCountdownMin { get => spawnCountdownMin; private set => spawnCountdownMin = value; }
    public float SpawnCountdownMax { get => spawnCountdownMax; private set => spawnCountdownMax = value; }

    protected virtual Transform Spawn(Vector3 spawnPosition)
    {
        Transform spawnedObject = Instantiate(spawnObjectTransform, spawnPosition, spawnObjectTransform.transform.rotation);
        return spawnedObject;
    }

    protected virtual float GetSpawnRandomCountdown() 
    {
        return Random.Range(SpawnCountdownMin, SpawnCountdownMax);
    }
}
