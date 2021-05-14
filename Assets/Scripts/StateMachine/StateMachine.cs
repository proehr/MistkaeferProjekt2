using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private State currentState;
    private StateHandler startHandler;
    private StateHandler playHandler;
    private StateHandler pauseHandler;
    private StateHandler winHandler;
    private StateHandler gameOverHandler;

    public void ResetGame()
    {
        currentState = State.Start;
    }

    public void RegisterStateHandlers(State state, StateHandler stateHandler)
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
        switch (transition)
        {
            case Transition.StartGame: 
                StartTransition(State.Start);
                return true;
            case Transition.PlayGame:
                StartTransition(State.Play);
                return true;
            case Transition.PauseGame:
                StartTransition(State.Pause);
                return true;
            case Transition.WinGame:
                StartTransition(State.Win);
                return true;
            case Transition.LoseGame:
                StartTransition(State.GameOver);
                return true;
            default: return false;
        }
    }

    public void StartTransition(State nextState)
    {
        if (currentState == nextState)
        {
            return;
        }
        StateHandler currentStateHandler = GetStateHandler(currentState);
        StateHandler nextStateHandler = GetStateHandler(nextState);
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
}
