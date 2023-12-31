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
        print("shield");
        player.PowerupShield();


    }

    //public IEnumerator ShieldTimer()
    //{
    //    //Player.hasShield = true;
    //    GameObject shieldObj = Instantiate(shieldPrefab);
    //    shieldObj.transform.SetParent(player.transform);
    //    shieldObj.transform.position = player.transform.position;
    //    yield return new WaitForSeconds(10f);
    //    Destroy(shieldObj);
    //    //Player.hasShield = false;
    //}
}
