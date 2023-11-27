using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet
{
    [SerializeField] private float flySpeed = 5f;

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
        transform.position += new Vector3(0, 1, 0) * Time.deltaTime * flySpeed;
    }
}
