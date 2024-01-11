using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public bool isInvisible;

    [SerializeField] private PlayerVisual playerVisual;
    [SerializeField] private CapsuleCollider2D capsuleCollider;
    [SerializeField] private float respawnCountdown;

    private void Start()
    {
        Player.instance.OnPlayerHit += Instance_OnPlayerHit;
    }

    private void Instance_OnPlayerHit(object sender, System.EventArgs e)
    {
        if (GameManager.sharedInstance.GetHitPointsValue() <= 0)
        {
            GameManager.sharedInstance.hitPoints.value = 0;
            GameOver();
            return;
        }
        StartCoroutine(WaitForRespawn(respawnCountdown));
        PlayerBulletManager.instance.DecreaseBulletLevel();
    }

    private IEnumerator WaitForRespawn(float time)
    {
        capsuleCollider.enabled = false;
        playerVisual.Hide();
        isInvisible = true;
        yield return new WaitForSeconds(time);
        capsuleCollider.enabled = true;
        playerVisual.Show();
        isInvisible = false;
    }

    private void GameOver()
    {
        capsuleCollider.enabled = false;
        playerVisual.Hide();
        isInvisible = true;
    }
}
