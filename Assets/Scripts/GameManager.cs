using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StateMachine.TriggerTransition(Transition.PauseGame);
        }
    }
}