using System;
using UnityEngine;

public class Ball : MonoBehaviour
{

    private void Update()
    {
        if (transform.position.y < -20)
        {
            StateMachine.TriggerTransition(Transition.LoseGame);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            StateMachine.TriggerTransition(Transition.WinGame);
        }
    }
}