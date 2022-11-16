using System;
using UnityEngine;

public class Coin : Collectable
{

    public static Action getCoin;
    public override void OnCollisionEnter2D(Collision2D col)
    {
        base.OnCollisionEnter2D(col);
        
        getCoin?.Invoke();
    }
}
