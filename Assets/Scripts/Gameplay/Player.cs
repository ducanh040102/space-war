using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameUIController gameUIController;

    private PGunBulletSpawner dPBullet;
    private PlayerBulletSpawnTwoWay twoWayPBullet;

    
    public Nuke nuke;
    [SerializeField] private int maxHitPoints;
    public GameObject laserObject;
    public GameObject shieldPrefab;
    public bool hasShield = false;

    public enum TypeOfBullet
    {
        DefaultBullet,
        TwoWayBullet,
        Laser
    }

    public TypeOfBullet typeBullet = TypeOfBullet.DefaultBullet;

    public void Start()
    {
        
        dPBullet = this.gameObject.GetComponent<PGunBulletSpawner>();
        twoWayPBullet = this.gameObject.GetComponent<PlayerBulletSpawnTwoWay>();
    }

    void Update()
    {
        MoveWithMouse();
        Fire();
      
    }

    private void MoveWithMouse()
    {
        if (Camera.main != null)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            
            if(mousePos.x > ScreenBoundary.Instance.ScreenWidth || mousePos.x < -ScreenBoundary.Instance.ScreenWidth ||
                mousePos.y > ScreenBoundary.Instance.ScreenHeight || mousePos.y < -ScreenBoundary.Instance.ScreenHeight) {
                return;
            }
            transform.position = mousePos;
        }
    }

    private void Fire()
    {
        if (Input.GetMouseButtonDown(0) && typeBullet == TypeOfBullet.DefaultBullet)
        {
            dPBullet.FireBullet();
        }
        else if (Input.GetMouseButtonDown(0) && typeBullet == TypeOfBullet.TwoWayBullet)
        {
            twoWayPBullet.FireBullet();
        }
    }

    public void Damaged(int damage)
    {
        if (hasShield == true)
        {
            return;
        }

        gameUIController.DecreHitPoints();
        //explosion o day
        if (gameUIController.GetHitPoints() <= 0)
        {
            KillPlayer();
        }
    }

    public void KillPlayer()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Damaged(1);
        }
    }

    public void PowerupHealth()
    {
        if (gameUIController.GetHitPoints() < maxHitPoints)
        {
            gameUIController.IncreHitPoints();

        }
    }

    public void PowerupNuke()
    {
        gameUIController.IncreNuke();
    }

    public void PowerupShield()
    {
        StartCoroutine(ShiledTimer());
    }

    public void PowerupLaser()
    {
        StartCoroutine(LaserTimer());
    }

    public void PowerupTwoWayShot()
    {
        PlayerBulletSpawnTwoWay.bulletCounts++;
        //StartCoroutine(TwoWayShotTimer());
        //typeBullet = TypeOfBullet.DefaultBullet;

    }

    public IEnumerator ShiledTimer()
    {
        hasShield = true;
        GameObject shieldObject = Instantiate(shieldPrefab);
        shieldObject.transform.SetParent(this.transform);
        shieldObject.transform.position = this.transform.position;
        yield return new WaitForSeconds(10f);
        Destroy(shieldObject);
        hasShield= false;
    }

    public IEnumerator LaserTimer()
    {
        //typeBullet = TypeOfBullet.Laser;
        laserObject.SetActive(true);
        yield return new WaitForSeconds(10f);
        laserObject.SetActive(false);
        typeBullet = TypeOfBullet.DefaultBullet;
    }

    //public IEnumerator TwoWayShotTimer()
    //{
        
    //    yield return new WaitForSeconds(10f);
    //    typeBullet = TypeOfBullet.DefaultBullet;
    //}
}
