using DG.Tweening;
using System.Collections;
using UnityEngine;

public class ClawBoss : Enemy
{

    [SerializeField] private Vector3[] moveDestinations;
    [SerializeField] private ObjectMoveInScene objectMoveInScene;
    [SerializeField] private Transform player;
    [SerializeField] private Animator clawAnimator;

    private Vector3 spawnPosition;
    
    private bool isFollowingPlayer = false;
    private Tween move;

    private void Start()
    {
        InitHP();
        StartCoroutine(WaitForAttack());
        StartCoroutine(WaitForSpawnMore());
    }

    protected override IEnumerator WaitForAttack()
    {
        while (!isStartAction)
        {
            yield return null;
        }
        spawnPosition = transform.position;
        Attack();
        StartCoroutine(WaitForDoSpecial());

    }
    
    private IEnumerator WaitForDoSpecial()
    {
        while (hitPoint != (int)(hitPointMax/2))
        {
            yield return null;
        }
        move.Pause();
        enemyBulletSpawner.isFiring = false;
        transform.DOMove(spawnPosition, 3f).SetEase(Ease.InSine);
        clawAnimator.SetTrigger("ballAttack");
        yield return new WaitForSeconds(5f);
        DoSpecial();
    }
    
    private IEnumerator WaitForEndSpecial()
    {
        yield return new WaitForSeconds(20f);
        EndSpecial();

    }

    private IEnumerator WaitForSpawnMore()
    {
        yield return new WaitForSeconds(50f);
        EnemySpawner.Instance.LoadCSVAndSpawnEnemy(301);
    }


    private void Update()
    {
        OutBoader();
        FollowingPlayer();
        Fire(enemyBulletSpawner.isFiring);
    }


    private void Attack()
    {
        enemyBulletSpawner.isFiring = true;
        move = transform.DOLocalPath(moveDestinations, 30f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }

    private void DoSpecial()
    {
        
        isFollowingPlayer = true;
        objectMoveInScene.move = ObjectMoveInScene.Move.Down;
        
        StartCoroutine(WaitForEndSpecial());
        
    }

    private void EndSpecial()
    {
        isFollowingPlayer = false;
        objectMoveInScene.move = ObjectMoveInScene.Move.Still;
        clawAnimator.SetTrigger("idle");
        
        transform.DOMove(spawnPosition, 2f).OnComplete(() =>
        {
            Attack();
        });
    }

    private void OutBoader()
    {
        if (transform.position.y < -ScreenBoundary.Instance.ScreenHeight)
        {
            transform.position = new Vector3(transform.position.x, ScreenBoundary.Instance.ScreenHeight, 0);
        }
    }

    private void ChangeAnimation()
    {

    }

    private void FollowingPlayer()
    {
        player = GameObject.Find("Player").transform;
        if (!isFollowingPlayer || player == null)
        {
            return;
        }
        float step = 5f * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x, transform.position.y, transform.position.z), step);
    }


}
