using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gameLevel;
    int currentLevel;
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        GoldBall.gameWin += SaveGameLevelToPlayerPrefs;
        
        if (currentLevel > 0)
            SetGameLevel();
    }

    void SaveGameLevelToPlayerPrefs()
    {
        var level = currentLevel;

        var saveLevel = level + 1;
        PlayerPrefs.SetInt("gameLevel", saveLevel);
    }

    void SetGameLevel()
    {
        gameLevel.text = "Level: " + currentLevel;
    }

    void OnDisable()
    {
        GoldBall.gameWin -= SaveGameLevelToPlayerPrefs;
    }
}
