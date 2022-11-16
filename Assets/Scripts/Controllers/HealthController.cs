using System;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public static Action healthBecomeZero;
    
    [SerializeField] List<GameObject> healths = new List<GameObject>();

    int damageTakeCount = 0;
    void Start()
    {
        BallHandler.ballIsThrown += TakeDamage;
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
            healthBecomeZero?.Invoke();
        }
        
    }

    void OnDisable()
    {
        BallHandler.ballIsThrown -= TakeDamage;
    }
}
