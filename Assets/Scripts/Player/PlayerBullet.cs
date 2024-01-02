using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet
{
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
        CrossBoarderDestroySelf();
    }
}
