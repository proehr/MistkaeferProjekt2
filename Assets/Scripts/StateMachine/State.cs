using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public delegate void EnterEvent();
    public delegate void ExitEvent();
    
    public abstract void OnEnter();
    public abstract void OnExit();
}
