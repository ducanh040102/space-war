using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletManager : MonoBehaviour
{
    public static PlayerBulletManager instance;

    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private float attackInterval;


    private PMainGun pMainGun;
    private PDoubleshotGun pDoubleshotGun;
    private PRocketGun pRocketGun;
    private GameObject pLaser;
    private Laser laser;
    private Respawn respawn;
    private TypeOfBullet previousTypeBullet;

    [SerializeField] private float attackIntervalCountdown;

    public enum TypeOfBullet
    {
        MainGun,
        DoubleshotGun,
        Laser
    }

    public TypeOfBullet typeBullet = TypeOfBullet.Laser;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        previousTypeBullet = typeBullet;
        attackIntervalCountdown = 0;

        respawn = gameObject.GetComponent<Respawn>();
        pMainGun = gameObject.GetComponent<PMainGun>();
        pDoubleshotGun = gameObject.GetComponent<PDoubleshotGun>();
        pRocketGun = gameObject.gameObject.GetComponent<PRocketGun>();
        pLaser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
        laser = pLaser.GetComponent<Laser>();
    }

    void Update()
    {
        Fire();
        FireRocket();
        ChangeBulletType();

        if(attackIntervalCountdown > 0)
        {
            attackIntervalCountdown -= Time.deltaTime;
        }
    }

    private void ChangeBulletType()
    {
        if(typeBullet != previousTypeBullet)
        {
            laser.DisableLaser();
            previousTypeBullet = typeBullet;
        }
    }

    private void Fire()
    {
        if (respawn.isRespawn)
        {
            laser.DisableLaser();
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (typeBullet == TypeOfBullet.MainGun)
                pMainGun.FireBullet();
            if (typeBullet == TypeOfBullet.DoubleshotGun)
                pDoubleshotGun.FireBullet();
            if (typeBullet == TypeOfBullet.Laser)
                laser.EnableLaser();
        }
        if (Input.GetMouseButton(0))
        {
            if (typeBullet == TypeOfBullet.Laser)
                laser.UpdateLaser(transform, Vector3.up);
            else
            {
                if (attackIntervalCountdown <= 0)
                {
                    if (typeBullet == TypeOfBullet.DoubleshotGun)
                        pDoubleshotGun.FireBullet();
                    if (typeBullet == TypeOfBullet.MainGun)
                        pMainGun.FireBullet();
                    attackIntervalCountdown = attackInterval;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            laser.DisableLaser();
        }
            
    }

    private void FireRocket()
    {
        if (Input.GetKeyDown(KeyCode.Space) && GameManager.sharedInstance.GetNukeValue() > 0)
        {
            pRocketGun.Fire();
            GameManager.sharedInstance.DecreNuke();
        }
    }
}
