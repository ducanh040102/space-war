using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    public GameObject[] powerups;
    public float powerupDropChance = .1f;



    public void SpawnPowerup(Transform pos)
    {
        
        if (Random.value < powerupDropChance)
        {
            GameObject powerup = powerups[Random.Range(0, powerups.Length)];
           
            
            Instantiate(powerup, pos.position, Quaternion.identity);
        }
    }
}
