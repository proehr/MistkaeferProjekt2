using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private State currentState;
    [SerializeField] private StateHandler startHandler;
    [SerializeField] private StateHandler playHandler;
    [SerializeField] private StateHandler pauseHandler;
    [SerializeField] private StateHandler winHandler;
    [SerializeField] private StateHandler gameOverHandler;

    void Awake()
    {
        GameObject[] gameControllers = GameObject.FindGameObjectsWithTag("GameController");
        if (gameControllers.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        currentState = State.Start;
    }
    
    public void ResetGame()
    {
        currentState = State.Start;
    }

    public void RegisterStateHandler(State state, StateHandler stateHandler)
    {
        switch (state)
        {
            case State.Start: startHandler = stateHandler;
                break;
            case State.Play: playHandler = stateHandler;
                break;
            case State.Pause: pauseHandler = stateHandler;
                break;
            case State.Win: winHandler = stateHandler;
                break;
            case State.GameOver: gameOverHandler = stateHandler;
                break;
        }
    }

    public bool TriggerTransition(Transition transition)
    {
        Debug.Log("triggered transition " + transition + " from " + currentState);
        switch (transition)
        {
            case Transition.StartGame:
                if (currentState == State.Start || currentState == State.Pause
                                                || currentState == State.Win || currentState == State.GameOver)
                {
                    MakeTransition(State.Start);
                    return true;
                }

                return false;
            case Transition.PlayGame:
                if (currentState == State.Play || currentState == State.Start
                                               || currentState == State.Pause)
                {
                    MakeTransition(State.Play);
                    return true;
                }

                return false;
            case Transition.PauseGame:
                if (currentState == State.Pause || currentState == State.Play)
                {
                    MakeTransition(State.Pause);
                    return true;
                }

                return false;
            case Transition.WinGame:
                if (currentState == State.Win || currentState == State.Play)
                {
                    MakeTransition(State.Win);
                    return true;
                }
                return false;
            case Transition.LoseGame:
                if (currentState == State.GameOver || currentState == State.Play)
                {
                    MakeTransition(State.GameOver);
                    return true;
                }
                return false;
            default: return false;
        }
    }

    public void MakeTransition(State nextState)
    {
        if (currentState == nextState)
        {
            return;
        }
        StateHandler currentStateHandler = GetStateHandler(currentState);
        StateHandler nextStateHandler = GetStateHandler(nextState);
        PrintTransition(nextState);
        currentStateHandler?.OnExit();
        nextStateHandler?.OnEnter();
        currentState = nextState;
    }

    public StateHandler GetStateHandler(State state)
    {
        switch (state)
        {
            case State.Start: return startHandler;
            case State.Play: return playHandler;
            case State.Pause: return pauseHandler;
            case State.Win: return winHandler;
            case State.GameOver: return gameOverHandler;
            default: return null;
        }
    }

    private void PrintTransition(State newState)
    {
        Debug.Log("Transitioning from " + currentState + "  to " + newState);
    }
}
