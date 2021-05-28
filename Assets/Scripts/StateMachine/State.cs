using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    private protected static State instance;
    public delegate void EnterEvent();
    public delegate void ExitEvent();
    
    public abstract void OnEnter();
    public abstract void OnExit();
}
