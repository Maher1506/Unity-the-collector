using UnityEditor;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string PLAYER_NAME_KEY = "Player Name";
    const string PLAYER_SCORE_KEY = "Score";
    const string PLAYER_BESTSCORE_KEY = "Best Score";
    const string THEME_KEY = "Theme";

    public static void SetPlayerName(string playerName)
    {
        PlayerPrefs.SetString(PLAYER_NAME_KEY, playerName);
        StartLootLockerSession.SetPlayerName();
    }
    public static void SetPlayerScore(int playerScore) 
    { 
        PlayerPrefs.SetInt(PLAYER_SCORE_KEY, playerScore);    
    }
    public static void SetPlayerBestScore(int bestScore)
    {
        PlayerPrefs.SetInt(PLAYER_BESTSCORE_KEY, bestScore);
    }
    public static void SetTheme(string theme)
    {
        PlayerPrefs.SetString(THEME_KEY, theme);
    }

    public static string GetPlayerName()
    {
        if (PlayerPrefs.HasKey(PLAYER_NAME_KEY))
        {
            return PlayerPrefs.GetString(PLAYER_NAME_KEY);
        }

        if (PlayerPrefs.HasKey("PlayerID"))
        {
            return "Guest_" + PlayerPrefs.GetString("PlayerID");
        }

        return "Guest_" + "AA10" + Random.Range(0, 9999) + "TH";
    }
    public static int GetPlayerScore()
    {
        return PlayerPrefs.GetInt(PLAYER_SCORE_KEY);
    }
    public static int GetPlayerBestScore()
    {
        return PlayerPrefs.GetInt(PLAYER_BESTSCORE_KEY);
    }
    public static string GetTheme()
    {
        return PlayerPrefs.GetString(THEME_KEY);
    }
}
