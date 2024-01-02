using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float damage;

    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private float maxLength;
    [SerializeField] private LayerMask obstacleLayer;
    


    void Start()
    {
        lineRenderer.enabled = false;
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
    }



    public void UpdateLaser()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, maxLength, obstacleLayer);

        Vector3 hitPosition = hit ? new Vector3(0, hit.distance + .1f, 0) : transform.position + transform.up * maxLength;

        lineRenderer.SetPosition(1, new Vector3(0, Math.Abs(hitPosition.y), 0));

        if (hit.collider != null)
        {
            Enemy enemy = hit.collider.GetComponent<Enemy>();
            enemy.GotHit(damage * Time.deltaTime);
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
