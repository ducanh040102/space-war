using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerup : PowerUp
{
    private Player player;
    

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    protected override void ActPowerup()
    {
        player.PowerupShield();
    }

}
