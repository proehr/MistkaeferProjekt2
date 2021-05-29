﻿using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StateMachine.TriggerTransition(Transition.PauseGame);
        }
    }
}