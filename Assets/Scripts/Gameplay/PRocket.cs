using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PRocket : MonoBehaviour
{
    public float explosionRadius;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Explode()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {

            }
        }
    }
}
