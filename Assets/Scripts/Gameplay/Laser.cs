using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Transform firePoint;
    public LineRenderer lineRenderer;
    public float maxDistance;
    public LayerMask obstacleLayer;

    public GameObject obj;
    void Start()
    {
        lineRenderer.enabled = true;

    }

   
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            EnableLaser();
        }

        if (Input.GetMouseButton(0))
        {
            UpdateLaser();
        }

        if (Input.GetMouseButtonUp(0))
        {
            DisableLaser();
        }
        //UpdateLaser();
    }

    public void UpdateLaser()
    {
        //lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, new Vector3(0,12,0));

        RaycastHit2D hit = Physics2D.Raycast( (Vector2)transform.position, transform.up, maxDistance, obstacleLayer);
        if (hit)
        {
           
            lineRenderer.SetPosition(1, new Vector3(0, Vector2.Distance(transform.position, obj.transform.position), 0));
        }
    }

    public void EnableLaser()
    {
        lineRenderer.enabled = true;


    }

    public void DisableLaser()
    {
        lineRenderer.enabled = false;


    }

}
