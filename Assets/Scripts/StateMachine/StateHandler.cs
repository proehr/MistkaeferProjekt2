using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateHandler : MonoBehaviour
{
    public abstract void OnEnter();
    public abstract void OnExit();
}
