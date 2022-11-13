using System;
using UnityEngine;

public class ButtonSessions : MonoBehaviour
{
    public static Action buttonClicked;

    public void ButtonClickSound()
    {
        buttonClicked?.Invoke();
    }
}
