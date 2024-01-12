using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected virtual void CrossBoarderDestroySelf()
    {
        if (!ScreenBoundary.Instance.IsInsideScreen(transform.position))
        {
            BackToPool();
        }
    }

    public void BackToPool()
    {
        gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        gameObject.SetActive(false);
    }
}
