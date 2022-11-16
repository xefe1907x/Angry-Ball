using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSessions : MonoBehaviour
{
    public static Action buttonClicked;
    public static Action clickedButton2;
    public static Action clickedButton3;

    public void ButtonClickSound()
    {
        buttonClicked?.Invoke();
    }

    public void StartGameButton()
    {
        Invoke("StartGame", 0.5f);
    }
    
    void StartGame()
    {
        var level = PlayerPrefs.GetInt("gameLevel");

        if (level == 0)
            level = 1;

        SceneManager.LoadScene(level);
    }

    #region BuyButtons
    
    public void ButtonBeforeBuy2()
    {
        clickedButton2?.Invoke();
    }
    
    public void ButtonBeforeBuy3()
    {
        clickedButton3?.Invoke();
    }
    
    public void ButtonAfterBuy1()
    {
        PlayerPrefs.SetInt("gameBall", 0);
    }
    
    public void ButtonAfterBuy2()
    {
        PlayerPrefs.SetInt("gameBall", 1);
    }
    
    public void ButtonAfterBuy3()
    {
        PlayerPrefs.SetInt("gameBall", 2);
    }
    
    #endregion

    public void TryAgainButton()
    {
        Invoke(nameof(LoadCurrentLevel), 0.5f);
    }
    
    void LoadCurrentLevel()
    {
        var currentLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentLevel);
    }

    public void MainMenuButton()
    {
        Invoke(nameof(GoMainMenu), 0.5f);
    }

    void GoMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void NextLevelButton()
    {
        Invoke(nameof(LoadNextLevel), 0.5f);
    }

    void LoadNextLevel()
    {
        var currentScene = SceneManager.GetActiveScene().buildIndex;
        var nextScene = currentScene + 1;
        SceneManager.LoadScene(nextScene);
    }
}
