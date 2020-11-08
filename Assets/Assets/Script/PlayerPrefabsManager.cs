using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefabsManager : MonoBehaviour
{
    const string SCORE_KEY = "score_key";
    const string HIGH_SCORE_KEY = "high_score_key";

    #region score
    public static void SetScoreKey (int score)
    {
        PlayerPrefs.SetInt(SCORE_KEY, score);
    }

    public static int GetScoreKey()
    {
        return PlayerPrefs.GetInt(SCORE_KEY);
    }
    #endregion score

    #region high score
    public static void SetHighScoreKey(int score)
    {
        PlayerPrefs.SetInt(HIGH_SCORE_KEY, score);
    }

    public static int GetHighScoreKey()
    {
        return PlayerPrefs.GetInt(HIGH_SCORE_KEY);
    }
    #endregion high score
}
