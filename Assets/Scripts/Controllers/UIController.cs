using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject losePanel;
    [SerializeField] GameObject winPanel;

    float delayOpenPanels = 3f;

    void Start()
    {
        HealthController.healthBecomeZero += LosePanelActivator;
    }

    void LosePanelActivator()
    {
        Invoke(nameof(OpenLosePanel), delayOpenPanels);
    }

    void OpenLosePanel()
    {
        losePanel.SetActive(true);
    }

    void OnDisable()
    {
        HealthController.healthBecomeZero -= LosePanelActivator;
    }
}
