using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PRocket : MonoBehaviour
{
    public float explosionRadius;
    public float moveSpeed;
    public float damage;

    void Update()
    {
        Move();
        CrossBoarderDestroySelf();
    }

    private void Move()
    {
        transform.Translate(transform.up * Time.deltaTime * moveSpeed);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Boss"))
        {
            Explode();
        }
    }


    void Explode()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Enemy") || collider.CompareTag("Boss"))
            {
                Enemy enemy = collider.GetComponent<Enemy>();
                enemy.Hit(damage);
            }
        }
        Destroy(gameObject);
    }

    void CrossBoarderDestroySelf()
    {
        if (transform.position.y < ScreenBoundary.Instance.ScreenWidth && transform.position.y > -ScreenBoundary.Instance.ScreenWidth)
            return;
        Destroy(gameObject);
    }
}
