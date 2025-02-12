using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DBManager 
{
    public const string SCORE = "score";

    public const string VOLUME = "volume";

    public static void SaveVolume(bool volume)
    {
        PlayerPrefs.SetInt(VOLUME, Convert.ToInt32(volume));
    }

    public static bool GetVolume()
    {
        return Convert.ToBoolean(PlayerPrefs.GetInt(VOLUME));
    }

    public static int GetSavedScore()
    {
        return PlayerPrefs.GetInt(SCORE, 0);
    }

    public static void SaveScore(int score)
    {
        int previousScore = GetSavedScore();
        
        if(score > previousScore)
        {
            PlayerPrefs.SetInt(SCORE, score);
        }

    }
}
