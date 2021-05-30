using Maze;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetUpState : State
{
    private static State instance;
    public static event EnterEvent OnEnterSetUpEvent;
    public static event ExitEvent OnExitSetUpEvent;

    public override void OnEnter()
    {
        if (OnEnterSetUpEvent != null)
        {
            OnEnterSetUpEvent();
        }
    }

    public override void OnExit()
    {
        if (OnExitSetUpEvent != null)
        {
            OnExitSetUpEvent();
        }
    }

    /**
     * returns instance of SetUpState and creates an instance if one doesn't exist
     */
    public static State GetInstance()
    {
        if (instance == null)
        {
            instance = new SetUpState();
        }

        return instance;
    }

    private SetUpState()
    {
    }
}