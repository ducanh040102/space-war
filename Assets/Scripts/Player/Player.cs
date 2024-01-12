using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    [SerializeField] private GameObject shieldPrefab;

    [SerializeField] private bool hasShield = false;
    [SerializeField] private float moveSpeed;

    public event EventHandler OnPlayerHit;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (PauseMenu.isPaused)
            return;
        MoveWithMouse();
    }

    private void MoveWithMouse()
    {

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        Vector3 direction = mousePos - transform.position;

        if (ScreenBoundary.Instance.IsInsideScreen(mousePos))
        {
            transform.position += direction * Time.deltaTime * moveSpeed;
        }
    }

    public void Damage()
    {
        if (hasShield == true)
        {
            return;
        }
        
        GameManager.sharedInstance.DecreHitPoints();
        OnPlayerHit?.Invoke(this, EventArgs.Empty);
    }

    public void GameOver()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasShield)
            return;

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Damage();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            collision.gameObject.SetActive(false);
            Damage();
        }
    }

    public void PowerupShield(float duration)
    {
        StartCoroutine(ShieldTimer(duration));
    }

    public IEnumerator ShieldTimer(float duration)
    {
        hasShield = true;
        GameObject shieldObj = Instantiate(shieldPrefab, transform);
        shieldObj.transform.position = transform.position;
        yield return new WaitForSeconds(duration);
        Destroy(shieldObj);
        hasShield = false;
    }

}
