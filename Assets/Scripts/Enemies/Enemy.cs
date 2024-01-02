using DG.Tweening;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float hitPointMax = 50;
    [SerializeField] protected EnemyBulletSpawner enemyBulletSpawner;
    [SerializeField] protected bool isStartAction = false;

    [SerializeField] protected float hitPoint;

    public GameUIController gameUIController;
    public PowerupSpawner powerupSpawner;
    public GameObject explosion;

    public void InitStats()
    {
        gameUIController = GameUIController.sharedInstance;
        powerupSpawner = PowerupSpawner.sharedInstance;

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
    

    public void GotHit(float damage)
    {
        hitPoint -= damage;

        if (hitPoint <= 0)
        {
            if (gameObject.CompareTag("Boss")){
                gameUIController.UpdateScore(1000);
            }
            else
            {
                gameUIController.UpdateScore(50);
            }
            
            powerupSpawner.SpawnPowerup(this.transform);
            Instantiate(explosion, transform.position, Quaternion.identity);
            GotDestroy();
        }
        
    }

    private void GotDestroy()
    {
        transform.DOKill();
        EnemySpawner.Instance.enemySpawnedList.Remove(transform);
        Destroy(gameObject);
    }

    protected virtual IEnumerator WaitForAttack()
    {
        while (!isStartAction)
        {
            yield return null;
        }
        enemyBulletSpawner.isFiring = true;
    }


}
