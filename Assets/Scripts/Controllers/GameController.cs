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
        
        if (currentLevel > 0)
            SetGameLevel();
    }

    void SetGameLevel()
    {
        gameLevel.text = "Level: " + currentLevel;


    }
}
