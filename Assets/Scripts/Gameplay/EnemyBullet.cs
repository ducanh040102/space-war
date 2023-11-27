using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
    [SerializeField] private float flySpeed = 5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.CompareTag("Player"))
    }

    void Update()
    {
        CrossBoarderDestroySelf();
        transform.position += new Vector3(0, -1, 0) * Time.deltaTime * flySpeed;
    }
}
