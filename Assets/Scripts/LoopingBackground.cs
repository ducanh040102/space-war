using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using Transform = UnityEngine.Transform;

public class LoopingBackground : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 0.5f;

    [SerializeField] private Transform[] backgrounds;
    void Update()
    {
        ScrollAndReset();
    }

    private void ScrollAndReset()
    {
        if (transform.position.y <= -backgrounds[backgrounds.Length - 1].position.y)
            transform.position = Vector3.zero;
        transform.position -= Vector3.up * scrollSpeed * Time.deltaTime;
    }
}
