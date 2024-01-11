using DG.Tweening;
using System.Collections;
using UnityEngine;

public class ClawBoss : MonoBehaviour
{
    [SerializeField] private Vector3[] moveDestinations;

    [SerializeField] private Animator clawAnimator;

    private Vector3 spawnPosition;
    private bool isFollowingPlayer = false;

    private ObjectMoveInScene objectMoveInScene;
    private Enemy enemy;
    private EnemyBulletSpawner enemyBulletSpawner;
    private Tween move;

    private void Start()
    {
        objectMoveInScene = gameObject.GetComponent<ObjectMoveInScene>();
        enemy = gameObject.GetComponent<Enemy>();
        enemyBulletSpawner = gameObject.GetComponent<EnemyBulletSpawner>();
        AudioManager.instance.PlayBossTheme();

        StartCoroutine(WaitForStart());
        StartCoroutine(WaitForSpawnMore());
    }

    protected IEnumerator WaitForStart()
    {
        while (!enemy.IsStartAction)
        {
            yield return null;
        }

        spawnPosition = transform.position;
        Attack();
        StartCoroutine(WaitForDoSpecial());

    }
    
    private IEnumerator WaitForDoSpecial()
    {
        while (enemy.HitPoint > (int)(enemy.HitPointMax / 2))
        {
            yield return null;
        }
        move.Pause();
        enemyBulletSpawner.StopFiring();

        transform.DOMove(spawnPosition, 3f).SetEase(Ease.InSine);
        clawAnimator.SetTrigger("ballAttack");
        yield return new WaitForSeconds(5f);
        DoSpecial();
    }
    
    private IEnumerator WaitForEndSpecial()
    {
        yield return new WaitForSeconds(15f);
        EndSpecial();

    }

    private IEnumerator WaitForSpawnMore()
    {
        yield return new WaitForSeconds(50f);
        EnemySpawner.Instance.LoadCSVAndSpawnEnemy(301);
    }


    private void Update()
    {
        DropLoop();
        FollowingPlayerHorizontal();
    }


    private void Attack()
    {
        enemyBulletSpawner.StartFiring();
        move = transform.DOLocalPath(moveDestinations, 30f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }

    private void DoSpecial()
    {
        isFollowingPlayer = true;
        objectMoveInScene.UpdateMoveType(ObjectMoveInScene.Move.Down);
        
        StartCoroutine(WaitForEndSpecial());
        
    }

    private void EndSpecial()
    {
        isFollowingPlayer = false;
        objectMoveInScene.UpdateMoveType(ObjectMoveInScene.Move.Still);
        clawAnimator.SetTrigger("idle");
        
        transform.DOMove(spawnPosition, 2f).OnComplete(() =>
        {
            Attack();
        });
    }

    private void DropLoop()
    {
        if (!ScreenBoundary.Instance.IsInsideScreen(transform.position))
        {
            transform.position = new Vector3(transform.position.x, ScreenBoundary.Instance.ScreenHeight, 0);
        }
    }

    private void FollowingPlayerHorizontal()
    {
        if (!isFollowingPlayer || Player.instance == null)
        {
            return;
        }
        float step = 5f * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(Player.instance.transform.position.x, transform.position.y, transform.position.z), step);
    }

    private void OnDestroy()
    {
        if (!Application.isPlaying)
            return;

        StopAllCoroutines();
        EnemySpawner.Instance.HitAllEnemy(10000f);
        VFXManager.instance.SpawnExplosion(transform.position, Vector3.one * 10, 2, 0.2f);

        AudioManager.instance.PlayBigExplode();
        AudioManager.instance.PlayVictoryTheme();
    }
}
