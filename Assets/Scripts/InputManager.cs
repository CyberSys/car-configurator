using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static event Action OnPlayerHUDToggle;

    void Update()
    {
        ToggleHUD();
    }

    void ToggleHUD()
    {
        if (Input.GetKeyDown(KeyCode.H))
            OnPlayerHUDToggle?.Invoke();
    }
}
