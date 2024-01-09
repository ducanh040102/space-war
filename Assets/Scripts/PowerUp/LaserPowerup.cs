using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPowerup : PowerUp
{
    protected override void ActPowerup()
    {
        PlayerBulletManager.instance.typeBullet = PlayerBulletManager.TypeOfBullet.Laser;
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
