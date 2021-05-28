using UnityEngine;
using UnityEngine.SceneManagement;


public class WinState : State
{
    private static State instance;
    public static event EnterEvent OnEnterWinEvent;
    public static event ExitEvent OnExitWinEvent;

    public override void OnEnter()
    {
        if (OnEnterWinEvent != null)
        {
            OnEnterWinEvent();
        }
    }

    public override void OnExit()
    {
        if (OnExitWinEvent != null)
        {
            OnExitWinEvent();
        }
    }

    public static State GetInstance()
    {
        if (instance == null)
        {
            instance = new WinState();
        }

        return instance;
    }

    private WinState()
    {
    }
}