using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StateMachine
{
    private static State currentState = States.mainMenu;

    /**
     * checks whether triggered transition is valid and starts transition if possible
     */
    public static void TriggerTransition(Transition transition)
    {
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

    /**
     * calls exit and enter for the new and the old state
     * sets new state as current state
     */
    private static void MakeTransition(State nextState)
    {
        if (currentState.Equals(nextState))
        {
            return;
        }

        //PrintTransition(nextState);
        State oldState = currentState;
        currentState = nextState;
        oldState?.OnExit();
        nextState?.OnEnter();
    }

    /**
     * method to check which transition is happening
     */
    private static void PrintTransition(State newState)
    {
        Debug.Log("Transitioning from " + currentState + "  to " + newState);
    }
}