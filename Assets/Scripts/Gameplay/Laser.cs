using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public int damage;
    public LineRenderer lineRenderer;
    public float maxDistance;
    public LayerMask obstacleLayer;
    //public Transform firingPoint;
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

        //if (Input.GetMouseButton(0))
        //{
        //    UpdateLaser();
        //}

        //if (Input.GetMouseButtonUp(0))
        //{
        //    DisableLaser();
        //}
    }

    public void UpdateLaser()
    {
        lineRenderer.SetPosition(1, new Vector3(0,12,0));

        RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position, transform.up, maxDistance, obstacleLayer);
        if (hit)
        {
            lineRenderer.SetPosition(1, new Vector3(0, Vector2.Distance(transform.position, hit.point) + .1f, 0));
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                print("damage enemy");
                //enemy.GotHit(damage);
            }
        }
    }

    public IEnumerator LaserDamage()
    {

        yield return null;
    }
}
