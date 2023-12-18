using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] int powerupId;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {
                // 0 = health, 1 = nuke, 2 = shield
                switch (powerupId)
                {
                    case 0:
                        player.PowerupHealth();
                        break;
                    case 1:
                        player.PowerupNuke();
                        break;
                    case 2:
                        player.PowerupShield();
                        gameObject.transform.SetParent(player.transform);
                        gameObject.transform.position = player.transform.position;
                        break;
                    default: 
                        break;
                }

                //this.gameObject.SetActive(false);
            }
        }
    }


}
