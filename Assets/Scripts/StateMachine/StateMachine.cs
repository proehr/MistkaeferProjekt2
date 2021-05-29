using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    private static State currentState = States.mainMenu;

    public static void TriggerTransition(Transition transition)
    {
        Debug.Log(currentState);
        switch (transition)
        {
            case Transition.EnterMainMenu:
                if (currentState == States.mainMenu || currentState == States.pause
                                                    || currentState == States.win || currentState == States.gameOver)
                {
                    MakeTransition(States.mainMenu);
                }

                break;
            case Transition.SetUpGame:
                if (currentState == States.setUp || currentState == States.mainMenu
                                                 || currentState == States.win)
                {
                    MakeTransition(States.setUp);
                }

                break;
            case Transition.PlayGame:
                if (currentState == States.play || currentState == States.pause
                                                || currentState == States.setUp)
                {
                    MakeTransition(States.play);
                }

                break;
            case Transition.PauseGame:
                if (currentState == States.pause || currentState == States.play)
                {
                    MakeTransition(States.pause);
                }

                break;
            case Transition.WinGame:
                if (currentState == States.win || currentState == States.play)
                {
                    MakeTransition(States.win);
                }

                break;
            case Transition.LoseGame:
                if (currentState == States.gameOver || currentState == States.play)
                {
                    MakeTransition(States.gameOver);
                }

                break;
        }
    }

    private static void MakeTransition(State nextState)
    {
        if (currentState.Equals(nextState))
        {
            Debug.Log(nextState);
            return;
        }

        PrintTransition(nextState);
        State oldState = currentState;
        currentState = nextState;
        oldState?.OnExit();
        nextState?.OnEnter();
    }

    private static void PrintTransition(State newState)
    {
        Debug.Log("Transitioning from " + currentState + "  to " + newState);
    }
}