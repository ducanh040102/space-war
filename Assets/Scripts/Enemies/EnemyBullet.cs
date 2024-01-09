using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
    [SerializeField] private int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                player.Damage(damage);
                Destroy(gameObject);
            }
        }

        if (collision.CompareTag("Shield"))
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        CrossBoarderDestroySelf(); 
    }
}
