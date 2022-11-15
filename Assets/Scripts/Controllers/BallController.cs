using System;
using UnityEngine;

public class BallController : MonoBehaviour
{
    int ballType; // 0 = Football, 1 = Basketball, 2 = Volleyball

    string ballTag;

    public static Action<string> ballTagSelected;
    void Start()
    {
        BallSelector();
    }

    void BallSelector()
    {
        ballType = PlayerPrefs.GetInt("gameBall");

        if (ballType == 0)
            ballTag = "Football";
        else if (ballType == 1)
            ballTag = "Basketball";
        else if (ballType == 2)
            ballTag = "Volleyball";
        
        ballTagSelected?.Invoke(ballTag);
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
