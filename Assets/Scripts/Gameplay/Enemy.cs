using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float hitPointMax = 50;
    [SerializeField] protected EnemyBulletSpawner enemyBulletSpawner;
    [SerializeField] protected bool isStartAction = false;
    [SerializeField] protected bool isSpawningBullet = false;

    [SerializeField] protected float hitPoint;
    public GameObject[] powerups;
    public float powerupDropChance = .5f;

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
    

    public void GotHit(float damage)
    {
        hitPoint -= damage;
        if(hitPoint <= 0)
        {
            GotDestroy();
        }
    }

    private void GotDestroy()
    {
        EnemySpawner.Instance.enemySpawnedList.Remove(transform);
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        if (Random.value < powerupDropChance)
        {
            DropPowerup();
        }
    }

    void DropPowerup()
    {
        // Chon ngau nhien
        GameObject powerup = powerups[Random.Range(0, powerups.Length)];

        Instantiate(powerup, transform.position, Quaternion.identity);
    }
}
