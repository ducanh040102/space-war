using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 screenBoundary;

    void Start()
    {
        screenBoundary = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, transform.position.z));
    }

    protected void CrossBoarderDestroySelf()
    {

        if (transform.position.y < screenBoundary.y && transform.position.y > -screenBoundary.y)
            return;

        Destroy(gameObject);
    }
}
