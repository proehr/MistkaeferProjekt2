using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverState : State
{
    private static State instance;
    public static event EnterEvent OnEnterGameOverEvent;
    public static event ExitEvent OnExitGameOverEvent;

    public override void OnEnter()
    {
        if (OnEnterGameOverEvent != null)
        {
            OnEnterGameOverEvent();
        }
    }

    public override void OnExit()
    {
        if (OnExitGameOverEvent != null)
        {
            OnExitGameOverEvent();
        }
    }

    /**
     * returns instance of GameOverState and creates an instance if one doesn't exist
     */
    public static State GetInstance()
    {
        if (instance == null)
        {
            instance = new GameOverState();
        }

        return instance;
    }

    private GameOverState()
    {
    }
}