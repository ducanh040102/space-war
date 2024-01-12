using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletManager : MonoBehaviour
{
    public static PlayerBulletManager instance;

    public enum TypeOfBullet
    {
        MainGun,
        DoubleshotGun,
        Laser
    }

    public TypeOfBullet typeBullet = TypeOfBullet.Laser;

    [SerializeField] private int bulletLevel;
    [SerializeField] private float mainGunAttackInterval;
    [SerializeField] private float doubleshotGunAttackInterval;

    [SerializeField] private PMainGun mainGunPool;
    [SerializeField] private PDoubleshotGun doubleshotPool;
    [SerializeField] private PRocketGun rocketPool;
    [SerializeField] private GameObject laserPrefab;

    private GameObject pLaser;
    private Laser laser;
    private Respawn respawn;

    private TypeOfBullet previousTypeBullet;

    private float attackInterval;
    private float attackIntervalCountdown;

    public int BulletLevel { get => bulletLevel; private set => bulletLevel = value; }

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        previousTypeBullet = typeBullet;
        attackIntervalCountdown = 0;

        respawn = gameObject.GetComponent<Respawn>();

        pLaser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
        laser = pLaser.GetComponent<Laser>();
    }

    void Update()
    {
        if (PauseMenu.isPaused)
            return;
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

        if (typeBullet == TypeOfBullet.MainGun)
        {
            attackInterval = mainGunAttackInterval;
        }

        else if (typeBullet == TypeOfBullet.DoubleshotGun)
        {
            attackInterval = doubleshotGunAttackInterval;
        }
    }

    private void Fire()
    {
        if (respawn.isInvisible)
        {
            laser.DisableLaser();
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (typeBullet == TypeOfBullet.Laser)
            {
                laser.EnableLaser();
                AudioManager.instance.PlayPlayerShootLaser();
            }
                
            if (typeBullet == TypeOfBullet.MainGun)
                mainGunPool.FireBullet();
            if (typeBullet == TypeOfBullet.DoubleshotGun)
                doubleshotPool.FireBullet();
        }
        if (Input.GetMouseButton(0))
        {
            if (typeBullet == TypeOfBullet.Laser)
            {
                laser.UpdateLaser(transform, Vector3.up);
            }
                
            else
            {
                if (attackIntervalCountdown <= 0)
                {
                    if (typeBullet == TypeOfBullet.DoubleshotGun)
                        doubleshotPool.FireBullet();
                    if (typeBullet == TypeOfBullet.MainGun)
                        mainGunPool.FireBullet();

                    AudioManager.instance.PlayPlayerShoot();

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
            rocketPool.Fire();
            AudioManager.instance.PlayPlayerShootRocket();
            GameManager.sharedInstance.DecreNuke();
        }
    }

    public void IncreaseBulletLevel()
    {
        if(bulletLevel < 8)
            bulletLevel++;
    }
    
    public void DecreaseBulletLevel()
    {
        if(bulletLevel > 0)
            bulletLevel--;
    }
}
