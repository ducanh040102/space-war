using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Player;

public class LaserPowerup : PowerUp
{
    private Player player;
    

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    protected override void ActPowerup()
    {
        Player.typeBullet = TypeOfBullet.Laser;
        player.PowerupLaser();
    }
    //public IEnumerator LaserTimer()
    //{
        
    //    //laserObject.SetActive(true);
    //    GameObject laserObj = Instantiate(laserPrefab);
    //    //GameObject laserObj2 = Instantiate(laserPrefab);
        
    //    laserObj.transform.SetParent(player.transform);
    //    laserObj.transform.position = player.transform.GetChild(1).position + new Vector3(-.5f, 0, 0);

    //    //laserObj2.transform.SetParent(player.transform);
    //    //laserObj2.transform.position = player.transform.GetChild(1).position + new Vector3(.5f,0,0);

    //    yield return new WaitForSeconds(10f);
    //    //laserObject.SetActive(false);
    //    typeBullet = TypeOfBullet.MainGun;
    //}
}
