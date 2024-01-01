using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameUIController gameUIController;

    private PMainGun pMainGun;
    private PDoubleshotGun pDoubleshotGun;

    public GameObject laserPrefab;
    public GameObject shieldPrefab;

    public bool hasShield = false;

    public GameObject explosion;
    public PGameManager pGameManager;
  

    public enum TypeOfBullet
    {
        MainGun,
        DoubleshotGun,
        Laser
    }

    public static TypeOfBullet typeBullet = TypeOfBullet.MainGun;

    private void Awake()
    {
        typeBullet = TypeOfBullet.MainGun;
    }

    public void Start()
    {

        pMainGun = this.gameObject.GetComponent<PMainGun>();
        pDoubleshotGun = this.gameObject.GetComponent<PDoubleshotGun>();
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
        if (Input.GetMouseButtonDown(0) && typeBullet == TypeOfBullet.MainGun)
        {
            pMainGun.FireBullet();
        }
        else if (Input.GetMouseButtonDown(0) && typeBullet == TypeOfBullet.DoubleshotGun)
        {
            pDoubleshotGun.FireBullet();
        }
    }

    public void Damaged(int damage)
    {
        if (hasShield == true)
        {
            return;
        }

        gameUIController.DecreHitPoints();
        
        if (gameUIController.GetHitPoints() <= 0)
        {
            gameUIController.hitPoints.value = 0;
            KillPlayer();
        }
        else
        {
            pGameManager.RunEplosion(explosion);
            
        }

    }

    public void KillPlayer()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Damaged(1);
        }
    }

    public void PowerupLaser()
    {
        StartCoroutine(LaserTimer());
    }

    public void PowerupShield()
    {
        StartCoroutine(ShieldTimer());
    }

    public IEnumerator ShieldTimer()
    {
        hasShield = true;
        GameObject shieldObj = Instantiate(shieldPrefab);
        shieldObj.transform.SetParent(this.transform);
        shieldObj.transform.position = this.transform.position;
        yield return new WaitForSeconds(10f);
        Destroy(shieldObj);
        hasShield = false;
    }

    private IEnumerator LaserTimer()
    {
        GameObject laserObj = Instantiate(laserPrefab);
        //GameObject laserObj2 = Instantiate(laserPrefab);

        laserObj.transform.SetParent(this.transform);
        laserObj.transform.position = this.transform.GetChild(1).position;

        //laserObj2.transform.SetParent(player.transform);
        //laserObj2.transform.position = player.transform.GetChild(1).position + new Vector3(.5f,0,0);

        yield return new WaitForSeconds(10f);
        Destroy(laserObj);
        typeBullet = TypeOfBullet.MainGun;
    }
}
