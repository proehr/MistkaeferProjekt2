using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private PowerUpHandler powerUpHandler = null;
    private void Update()
    {
        if (transform.position.y < -20)
        {
            powerUpHandler.ResetEffects();
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