using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBoundary : MonoBehaviour
{
    private static ScreenBoundary instance;

    private float screenWidth;
    private float screenHeight;

    public static ScreenBoundary Instance { get => instance; private set => instance = value; }
    public float ScreenWidth { get => screenWidth; private set => screenWidth = value; }
    public float ScreenHeight { get => screenHeight; private set => screenHeight = value; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Vector3 screenSize = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, transform.position.z));
        ScreenWidth = screenSize.x;
        ScreenHeight = screenSize.y;
    }


}
