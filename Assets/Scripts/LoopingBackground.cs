using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using Transform = UnityEngine.Transform;

public class LoopingBackground : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 0.5f;

    private Vector3 startPos;
    private float repeatWidth;

    private void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider2D>().size.y * 0.5f;
    }

    void Update()
    {
        ScrollAndReset();
    }

    private void ScrollAndReset()
    {
        if (transform.position.y < startPos.y - repeatWidth - 1)
            transform.position = startPos;

        transform.position += Time.deltaTime * scrollSpeed * Vector3.down;

        
    }
}
