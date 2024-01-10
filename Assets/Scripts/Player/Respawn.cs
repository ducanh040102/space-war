using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public bool isRespawn;

    [SerializeField] private PlayerVisual playerVisual;
    [SerializeField] private CapsuleCollider2D capsuleCollider;
    [SerializeField] private float respawnCountdown;

    private void Start()
    {
        Player.instance.OnPlayerHit += Instance_OnPlayerHit;
    }

    private void Instance_OnPlayerHit(object sender, System.EventArgs e)
    {
        StartCoroutine(WaitForRespawn(respawnCountdown));
    }

    private IEnumerator WaitForRespawn(float time)
    {
        capsuleCollider.enabled = false;
        playerVisual.Hide();
        isRespawn = true;
        yield return new WaitForSeconds(time);
        capsuleCollider.enabled = true;
        playerVisual.Show();
        isRespawn = false;
    }
}
