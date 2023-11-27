using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    public enum Scene
    {
        Gameplay,
        MainMenu,
        Settings,
        Leaderboard,
        Loading
    }

    private static Scene targetScene;

    public static void Load(Scene scene )
    {
        Loader.targetScene = scene;

        SceneManager.LoadScene(Scene.Loading.ToString());
    }

    public static void LoaderCallback()
    {
        SceneManager.LoadScene(targetScene.ToString());
    }
}
