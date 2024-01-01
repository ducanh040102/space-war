using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PRocketGun : MonoBehaviour
{
    public GameObject rocketPrefab;
    public Transform firingPoint;
  
    public void Fire()
    {
        Instantiate(rocketPrefab, firingPoint.position, Quaternion.identity);
    }
}
