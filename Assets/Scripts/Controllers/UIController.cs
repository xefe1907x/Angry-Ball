using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject losePanel;
    [SerializeField] GameObject winPanel;

    float delayOpenPanels = 3f;

    void Start()
    {
        HealthController.healthBecomeZero += LosePanelActivator;
        GoldBall.gameWin += WinPanelActivator;
    }

    void LosePanelActivator()
    {
        Invoke(nameof(OpenLosePanel), delayOpenPanels);
    }

    void OpenLosePanel()
    {
        if (losePanel != null)
            losePanel.SetActive(true);
    }
    
    void WinPanelActivator()
    {
        losePanel = null;
        Invoke(nameof(OpenWinPanel), delayOpenPanels);
    }

    void OpenWinPanel()
    {
        winPanel.SetActive(true);
    }

    void OnDisable()
    {
        HealthController.healthBecomeZero -= LosePanelActivator;
        GoldBall.gameWin -= WinPanelActivator;
    }
}
