using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected virtual void CrossBoarderDestroySelf()
    {
        if (!ScreenBoundary.Instance.IsInsideScreen(transform.position))
            gameObject.SetActive(false);


    }
}
