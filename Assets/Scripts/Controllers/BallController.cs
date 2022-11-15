using UnityEngine;

public class BallController : MonoBehaviour
{
    int ballType; // 0 = Football, 1 = Basketball, 2 = Volleyball

    [SerializeField] GameObject footBall;
    [SerializeField] GameObject basketBall;
    [SerializeField] GameObject volleyBall;

    void Start()
    {
        BallSelector();
    }

    void BallSelector()
    {
        ballType = PlayerPrefs.GetInt("gameBall");
        
        if (ballType == 0)
            footBall.SetActive(true);
        else if (ballType == 1)
            basketBall.SetActive(true);
        else if (ballType == 2)
            volleyBall.SetActive(true);
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
