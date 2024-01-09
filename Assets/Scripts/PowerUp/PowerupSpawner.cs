using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    public static PowerupSpawner sharedInstance = null;

    [SerializeField] private GameObject[] powerups;
    [SerializeField] float powerupDropChance = .1f;

   
    private void Awake()
    {
        if (sharedInstance != null && sharedInstance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            sharedInstance = this;
        }
    }

    public void SpawnPowerup(Transform position)
    {
        if (Random.value < powerupDropChance)
        {
            GameObject powerup = powerups[Random.Range(0, powerups.Length)];

            Instantiate(powerup, position.position, Quaternion.identity);
        }
    }
}
