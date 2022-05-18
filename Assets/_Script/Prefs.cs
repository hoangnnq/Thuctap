using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Prefs
{
    public static int SelectPlayer
    {
        get => PlayerPrefs.GetInt(Const.SelectPlayer );

        set => PlayerPrefs.SetInt(Const.SelectPlayer, value);
    }
    public static int SceneLevel
    {
        get => PlayerPrefs.GetInt(Const.SceneLevel,1);

        set => PlayerPrefs.SetInt(Const.SelectPlayer, value);
    }
    public static int Score
    {
        get => PlayerPrefs.GetInt(Const.Score);

        set => PlayerPrefs.SetInt(Const.Score, value);
    }
    public static int HighScore
    {
        get => PlayerPrefs.GetInt(Const.HighScore);

        set => PlayerPrefs.SetInt(Const.HighScore, value);
    }
}
