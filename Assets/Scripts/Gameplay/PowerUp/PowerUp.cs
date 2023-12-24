using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Player;

public class PowerUp : MonoBehaviour
{
    [SerializeField] TypeOfPowerup typeOfPowerup;
    
    public enum TypeOfPowerup
    {
        Health,
        Nuke,
        Shield,
        TwoWayShot,
        Laser,
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

    }

}
