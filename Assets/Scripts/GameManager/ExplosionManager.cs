using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    public static VFXManager instance;

    [SerializeField] private Transform[] explosionPrefabs;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Player.instance.OnPlayerHit += Player_OnPlayerHit;
    }

    private void Player_OnPlayerHit(object sender, System.EventArgs e)
    {
        SpawnExplosion(Player.instance.transform.position, Vector3.one, 1);
    }

    public void SpawnExplosion(Vector3 position, Vector3 size, int type)
    {
        AudioManager.instance.PlayExplode();
        Transform explosion = Instantiate(explosionPrefabs[type], position, Quaternion.identity);
        explosion.localScale = size;
    }
}
