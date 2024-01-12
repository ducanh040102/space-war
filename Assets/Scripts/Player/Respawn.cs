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
        Player.instance.PowerupShield(3f);
        capsuleCollider.enabled = true;
        playerVisual.Show();
        isInvisible = false;
    }

    private void GameOver()
    {
        capsuleCollider.enabled = false;
        playerVisual.Hide();
        isInvisible = true;
        GameplayUI.instance.StageTextTrigger("GAME OVER","");
        StartCoroutine(WaitForEndGame());

    }

    IEnumerator WaitForEndGame()
    {
        yield return new WaitForSeconds(10f);
        Loader.Load(Loader.Scene.MainMenuScene);
    }
}
