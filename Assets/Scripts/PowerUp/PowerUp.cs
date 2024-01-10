using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Player;

public abstract class PowerUp : MonoBehaviour
{
    [SerializeField] private float speedFall = .5f;
    [SerializeField] private Vector3 direction = Vector3.down;
  
    private void Start()
    {
        Destroy(gameObject,15f);
    }

    private void Update()
    {
        Move();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {
                ActPowerup();
                Destroy(gameObject);
            }
        }
    }

    void Move()
    {
        transform.localPosition += direction * speedFall * Time.deltaTime;
    }

    protected abstract void ActPowerup();
}
