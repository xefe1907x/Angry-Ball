using System;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public static Action healthBecomeZero;
    
    [SerializeField] List<GameObject> healths = new List<GameObject>();

    bool winGame;

    int damageTakeCount = 0;
    void Start()
    {
        BallHandler.ballIsThrown += TakeDamage;
        GoldBall.gameWin += IfPlayerWinsGame;
    }

    void IfPlayerWinsGame()
    {
        winGame = true;
    }

    void TakeDamage()
    {
        damageTakeCount += 1;
        DecreaseHealth();
    }

    void DecreaseHealth()
    {
        if (damageTakeCount <= 3)
        {
            var startPoint = healths.Count - 1;
            var endPoint = startPoint - 1;

            for (int i = startPoint; i > endPoint; i--)
            {
                healths[i].SetActive(false);
                healths.Remove(healths[i]);
            }
        }
        
        if (damageTakeCount == 3)
        {
            if (!winGame)
                healthBecomeZero?.Invoke();
        }
    }

    void OnDisable()
    {
        BallHandler.ballIsThrown -= TakeDamage;
        GoldBall.gameWin -= IfPlayerWinsGame;
    }
}
