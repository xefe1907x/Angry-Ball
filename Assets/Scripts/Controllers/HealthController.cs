using System;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
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
        var startPoint = healths.Count - 1;
        var endPoint = startPoint - 1;

        for (int i = startPoint; i > endPoint; i--)
        {
            healths[i].SetActive(false);
            healths.Remove(healths[i]);
        }
    }

    void OnDisable()
    {
        BallHandler.ballIsThrown -= TakeDamage;
    }
}
