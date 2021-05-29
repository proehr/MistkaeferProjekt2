using System;
using UnityEngine;

public class Ball : MonoBehaviour
{

    private void Update()
    {
        if (transform.position.y < -20) // if player below the board -> either by falling off or by falling into one of the holes
        {
            StateMachine.TriggerTransition(Transition.LoseGame);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish")) // if player has reached the goal
        {
            StateMachine.TriggerTransition(Transition.WinGame);
        }
    }
}