using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateHandler : MonoBehaviour
{
    public StateMachine stateMachine;
    public abstract void Awake();
    public abstract void OnEnter();
    public abstract void OnExit();
}
