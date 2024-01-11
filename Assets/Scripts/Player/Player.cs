using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

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

    public void Damage(int damage)
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
