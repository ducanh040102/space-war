using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerBullet : Bullet
{
    public float moveSpeed;
    public float damage;
    public Vector3 direction;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.GotHit(damage);
                gameObject.SetActive(false);
            }
        }
    }

    void Update()
    {
        Move();
        CrossBoarderDestroySelf();
        
    }

    private void Move()
    {
        transform.Translate(transform.up * Time.deltaTime * moveSpeed);

    }

    protected override void CrossBoarderDestroySelf()
    {
        if (transform.position.y < ScreenBoundary.Instance.ScreenWidth && transform.position.y > -ScreenBoundary.Instance.ScreenWidth)
            return;
        gameObject.SetActive(false);
    }
}
