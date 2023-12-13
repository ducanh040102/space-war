using DG.Tweening;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float hitPointMax = 50;
    [SerializeField] protected EnemyBulletSpawner enemyBulletSpawner;
    [SerializeField] protected bool isStartAction = false;
    [SerializeField] protected bool isSpawningBullet = false;

    protected float hitPoint;


    public void InitHP()
    {
        hitPoint = hitPointMax;
    }

    public void Fire(bool isFiring)
    {
        if (isFiring)
            enemyBulletSpawner.SpawnBullet();
    }
    public void StartAction()
    {
        isStartAction = true;
    }
    

    public void GotHit()
    {
        if(isStartAction)
        {
            hitPoint -= 1;
            if (hitPoint <= 0)
            {
                GotDestroy();
            }
        }
        
    }

    private void GotDestroy()
    {
        transform.DOKill();
        EnemySpawner.Instance.enemySpawnedList.Remove(transform);
        Destroy(gameObject);
    }

    
}
