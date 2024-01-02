using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PGameManager : MonoBehaviour
{
    public GameObject player;

    public void RunEplosion(GameObject explosion)
    {
        StartCoroutine(StartExplosion(explosion));
    }

    public IEnumerator StartExplosion(GameObject explosion)
    {
        Instantiate(explosion, player.transform.position, Quaternion.identity);
        player.SetActive(false);
        yield return new WaitForSeconds(1f);
        player.SetActive(true);
    }
}
