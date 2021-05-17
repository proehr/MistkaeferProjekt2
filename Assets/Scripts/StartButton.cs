using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private StateMachine stateMachine;

    private void Awake()
    {
        stateMachine = FindObjectOfType<StateMachine>();
    }

    public void StartGame()
    {
        stateMachine.TriggerTransition(Transition.PlayGame);
        Debug.Log("starting game");
    }
}
