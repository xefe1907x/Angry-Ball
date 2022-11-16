using System;
using UnityEngine;

public class GoldBall : Collectable
{
    public static Action gameWin;
    public override void OnCollisionEnter2D(Collision2D col)
    {
        base.OnCollisionEnter2D(col);
        
        if(col.gameObject.CompareTag("Ball"))
            gameWin?.Invoke();
    }
}
