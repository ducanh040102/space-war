using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class PlayerBulletSpawnDefault : MonoBehaviour
{
    public GameObject bulletPrefab;
    List<GameObject> bulletPool;
    public int poolSize;

    public Transform firingPoint;

    private void Awake()
    {
        CreatePool();
    }

    private void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        {
            //FireBullet();
        }
    }

    public void CreatePool()
    {
        if (bulletPool == null)
        {
            bulletPool = new List<GameObject>();
        }
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bulletObject = Instantiate(bulletPrefab);
            bulletObject.transform.position = firingPoint.position;
            bulletObject.SetActive(false);
            bulletPool.Add(bulletObject);
        }
    }

    public GameObject SpawnBullet(Vector3 location)
    {
        foreach (GameObject bullet in bulletPool)
        {
            if (bullet.activeSelf == false)
            {
                bullet.SetActive(true);
                bullet.transform.position = location;
                return bullet;
            }
        }

        return null;
    }


    public virtual void FireBullet()
    {
        
        GameObject bullet = SpawnBullet(firingPoint.position);
        
    }

    private void OnDestroy()
    {
        bulletPool = null;
    }
}
