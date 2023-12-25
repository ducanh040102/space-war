using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerBulletSpawner playerBulletSpawner;

    [SerializeField] private AudioSource bulletSoundEffect;

    void Update()
    {
        MoveWithMouse();
        Fire();
    }

    private void MoveWithMouse()
    {
        if (Camera.main != null)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            
            if(mousePos.x > ScreenBoundary.Instance.ScreenWidth || mousePos.x < -ScreenBoundary.Instance.ScreenWidth ||
                mousePos.y > ScreenBoundary.Instance.ScreenHeight || mousePos.y < -ScreenBoundary.Instance.ScreenHeight) {
                return;
            }
            transform.position = mousePos;
        }
    }

    private void Fire()
    {
        if (Input.GetMouseButton(0))
        {
            playerBulletSpawner.SpawnBullet();
            bulletSoundEffect.Play();
        }
    }
}
