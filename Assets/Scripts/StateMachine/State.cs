using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** abstract class for states
 * consists of two events for entering and exiting the state
 * and two corresponding methods for calling the events
 */
public abstract class State
{
    public delegate void EnterEvent();
    public delegate void ExitEvent();
    
    public abstract void OnEnter();
    public abstract void OnExit();
}
