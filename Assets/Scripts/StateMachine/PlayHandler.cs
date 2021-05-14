using System;
using UnityEngine;

namespace UnityTemplateProjects
{
    public class PlayHandler : StateHandler
    {
        public override void Awake()
        {
            stateMachine = FindObjectOfType<StateMachine>();
            if (stateMachine != null)
            {
                stateMachine.RegisterStateHandler(State.Play, this);
            }
        }
        public override void OnEnter()
        {
            //set a timer for game
        }

        public override void OnExit()
        {
            // whatever needs to be done
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                stateMachine.TriggerTransition(Transition.PauseGame);
            }

            if (transform.position.y < -20)
            {
                stateMachine.TriggerTransition(Transition.LoseGame);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Finish")
            {
                stateMachine.TriggerTransition(Transition.WinGame);
            }
        }
    }
}