using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Transform firePoint;
    public GameObject laser; 

    void Start()
    {
        laser.SetActive(false);
    }

   
    void LateUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            
            EnableLaser();
        }

        //if (Input.GetMouseButton(0))
        //{
        //    DisableLaser();
        //}
    }

    public void EnableLaser()
    {
        laser.SetActive(true);
        laser.transform.position = firePoint.position;
    }

    public void DisableLaser()
    {
        laser.SetActive(false);

    }
}
