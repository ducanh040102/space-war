using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] TypeOfPowerup typeOfPowerup;
    

    protected Player player;


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
            player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {
                // 0 = health, 1 = nuke, 2 = shield
                switch (typeOfPowerup)
                {
                    case TypeOfPowerup.Health:
                        player.PowerupHealth();
                        this.gameObject.SetActive(false);
                        break;
                    case TypeOfPowerup.Nuke:
                        player.PowerupNuke();
                        this.gameObject.SetActive(false);
                        break;
                    case TypeOfPowerup.Shield:
                        player.PowerupShield();
                        gameObject.transform.SetParent(player.transform);
                        gameObject.transform.position = player.transform.position;
                        break;
                    case TypeOfPowerup.TwoWayShot:
                        break;
                    case TypeOfPowerup.Laser:
                        //StartCoroutine(LaserTimer());
                        this.gameObject.SetActive(false);

                        player.PowerupLase();

                        break;
                    default: 
                        break;
                }

                
            }
        }
    }

}
