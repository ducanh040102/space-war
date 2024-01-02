using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Laser : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Transform startVFX;
    [SerializeField] private Transform endVFX;

    private void Start()
    {
        DisableLaser();


        startVFX.position = transform.position;
    }

    void Update()
    {
        if (lineRenderer.enabled)
            UpdateLaser();
    }

    public void EnableLaser()
    {
        lineRenderer.enabled = true;
        startVFX.gameObject.SetActive(true);
        endVFX.gameObject.SetActive(true);
    }

    private void UpdateLaser()
    {
        
        Vector2 direction = (Vector2)(transform.position + new Vector3(0, -20, 0)) - (Vector2)transform.position;
        RaycastHit2D[] hit = Physics2D.RaycastAll((Vector2)transform.position, direction.normalized, 1000);

        for (int i = 0; i < hit.Length; i++)
        {
            if (hit[i].transform.name == "Player")
            {
                Debug.Log("Hit");
            }
        }

        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, hit[hit.Length - 1].point);

        endVFX.position = hit[hit.Length - 1].point;
    }

    public void DisableLaser()
    {
        lineRenderer.enabled = false;
        startVFX.gameObject.SetActive(false);
        endVFX.gameObject.SetActive(false);
    }
}
