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
        if (Camera.main != null)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            
            if(mousePos.x > ScreenBoundary.Instance.ScreenWidth || mousePos.x < -ScreenBoundary.Instance.ScreenWidth ||
                mousePos.y > ScreenBoundary.Instance.ScreenHeight || mousePos.y < -ScreenBoundary.Instance.ScreenHeight) {
                return;
            }

            Vector3 direction = mousePos - transform.position;
            transform.position += direction * Time.deltaTime * moveSpeed;
        }
    }

    public void Damage(int damage)
    {
        if (hasShield == true)
        {
            return;
        }

        GameManager.sharedInstance.DecreHitPoints();
        
        if (GameManager.sharedInstance.GetHitPointsValue() <= 0)
        {
            GameManager.sharedInstance.hitPoints.value = 0;
            //Destroy();
        }
        else
        {
            OnPlayerHit?.Invoke(this, EventArgs.Empty);
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasShield)
            return;

        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().Hit(1);
        }

        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            collision.gameObject.SetActive(false);
        }

        
        Damage(1);

    }

    public void PowerupShield()
    {
        StartCoroutine(ShieldTimer());
    }

    public IEnumerator ShieldTimer()
    {
        hasShield = true;
        GameObject shieldObj = Instantiate(shieldPrefab, this.transform);
        shieldObj.transform.position = this.transform.position;
        yield return new WaitForSeconds(10f);
        Destroy(shieldObj);
        hasShield = false;
    }

}
