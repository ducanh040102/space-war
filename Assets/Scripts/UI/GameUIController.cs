using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI hitPointText;
    [SerializeField] TextMeshProUGUI nukeText;

    public HitPoints hitPoints;
    public Nuke nuke;
    // Start is called before the first frame update
    void Start()
    {
        hitPointText.text = hitPoints.value.ToString();
        nukeText.text = nuke.value.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        hitPointText.text = hitPoints.value.ToString();
        nukeText.text = nuke.value.ToString();
    }
}
