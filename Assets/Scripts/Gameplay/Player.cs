using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerBulletSpawner playerBulletSpawner;

    public HitPoints hitPoints;
    public Nuke nuke;
    [SerializeField] private int maxHitPoints;
    public GameObject laserPrefab;
    DefaultShooter db;

    public bool isFireDefault = true;
    

    public bool hasShield = false;

    public void Start()
    {
        hitPoints.value = 5;
        nuke.value = 0;
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
        if (Input.GetMouseButton(0) && isFireDefault == true)
        {
            playerBulletSpawner.SpawnBullet();

            
        }
    }

    public void Damaged(int damage)
    {
        if (hasShield == false)
        {
            hitPoints.value -= damage;
        }
        
        if (hitPoints.value <= 0)
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
        if (hitPoints.value < maxHitPoints)
        {
            hitPoints.value++;

        }
    }

    public void PowerupNuke()
    {
        nuke.value++;
    }

    public void PowerupShield()
    {
        hasShield = true;
    }

    public void PowerupLase()
    {
        StartCoroutine(LaserTimer());
    }

    public IEnumerator LaserTimer()
    {
        isFireDefault = false;
        GameObject laserPre = Instantiate(laserPrefab);

        laserPre.transform.SetParent(this.transform);
        laserPre.transform.position = this.transform.position;
        yield return new WaitForSeconds(10f);
        Destroy(laserPre);
        isFireDefault= true;
    }

    public IEnumerator TwoWayShot()
    {
        // 1 ham ban 2 tia
        yield return new WaitForSeconds(5.0f);

    }
}
