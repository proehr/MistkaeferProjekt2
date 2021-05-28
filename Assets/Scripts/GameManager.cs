using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //[SerializeField] private GameObject ball;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StateMachine.TriggerTransition(Transition.PauseGame);
        }
    }
}