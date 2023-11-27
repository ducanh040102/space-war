using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform playerFiringPoint;
    [SerializeField] private Transform playerBullet;
    [SerializeField] private float playerFireCountdownMax = 0;

    private float playerFireCountdown = 0;
    private Vector3 screenBoundary;

    private void Start()
    {
        screenBoundary = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, transform.position.z));
    }

    void Update()
    {
        MoveWithMouse();
        Fire();
        playerFireCountdown -= Time.deltaTime;
    }

    private void MoveWithMouse()
    {
        if (Camera.main != null)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            

            if(mousePos.x < screenBoundary.x && mousePos.x > -screenBoundary.x) {
                if(mousePos.y < screenBoundary.y && mousePos.y > -screenBoundary.y)
                    transform.position = mousePos;
            }
        }
    }

    private void Fire()
    {
        if (Input.GetMouseButton(0))
        {
            if (playerFireCountdown <= 0)
            {
                SpawnBullet();
                playerFireCountdown = playerFireCountdownMax;
            }
            
        }
    }

    private void SpawnBullet()
    {
        Instantiate(playerBullet, playerFiringPoint.transform.position, playerBullet.transform.rotation);
    }

}
