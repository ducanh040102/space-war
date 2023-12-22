using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerBullet : Bullet
{
    public float moveSpeed;
    public Vector3 direction = Vector3.up;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.TryGetComponent<Enemy>(out Enemy enemy);
        if (enemy != null)
        {
            enemy.GotHit();
            Destroy(gameObject);
        }
    }

    void Update()
    {
        Move();
        CrossBoarderDestroySelf();
        
    }

    private void Move()
    {
        transform.localPosition += direction * Time.deltaTime * moveSpeed;
    }
}
