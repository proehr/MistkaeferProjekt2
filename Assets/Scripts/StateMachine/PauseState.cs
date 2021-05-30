using UnityEngine;

public class PauseState : State
{
    private static State instance;
    public static event EnterEvent OnEnterPauseEvent;
    public static event ExitEvent OnExitPauseEvent;

    public override void OnEnter()
    {
        if (OnEnterPauseEvent != null)
        {
            OnEnterPauseEvent();
        }
    }

    public override void OnExit()
    {
        if (OnExitPauseEvent != null)
        {
            OnExitPauseEvent();
        }
    }

    /**
     * returns instance of PauseState and creates an instance if one doesn't exist
     */
    public static State GetInstance()
    {
        if (instance == null)
        {
            instance = new PauseState();
        }

        return instance;
    }

    private PauseState()
    {
    }
}