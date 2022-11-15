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
}
