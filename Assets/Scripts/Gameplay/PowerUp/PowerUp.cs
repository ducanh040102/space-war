using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Player;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private TypeOfPowerup typeOfPowerup;
    [SerializeField] private float speedFall = .5f;
    [SerializeField] private Vector3 direction = Vector3.down;
    public enum TypeOfPowerup
    {
        Health,
        Nuke,
        Shield,
        TwoWayShot,
        Laser,
    }

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
                // 0 = health, 1 = nuke, 2 = shield, 3 = twowayshot, 4 = laser
                switch (typeOfPowerup)
                {
                    case TypeOfPowerup.Health:
                        player.PowerupHealth();
                        break;
                    case TypeOfPowerup.Nuke:
                        player.PowerupNuke();
                        break;
                    case TypeOfPowerup.Shield:
                        player.PowerupShield();
                        break;
                    case TypeOfPowerup.TwoWayShot:
                        player.typeBullet = TypeOfBullet.TwoWayBullet;
                        player.PowerupTwoWayShot();
                        break;
                    case TypeOfPowerup.Laser:
                        player.typeBullet = TypeOfBullet.Laser;
                        player.PowerupLaser();
                        break;
                    default: 
                        break;
                }

                Destroy(gameObject);

            }
        }
    }

    void Move()
    {
        transform.localPosition += direction * speedFall * Time.deltaTime;
    }

    //protected void CrossBoarderDestroySelf()
    //{
    //    Destroy(gameObject);
    //}
}
