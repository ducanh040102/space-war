using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected void CrossBoarderDestroySelf()
    {
        if (transform.position.y < ScreenBoundary.Instance.ScreenWidth && transform.position.y > - ScreenBoundary.Instance.ScreenWidth)
            return;

        Destroy(gameObject);
    }
}
