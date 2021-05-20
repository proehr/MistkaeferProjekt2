using UnityEngine;

namespace UnityTemplateProjects
{
    public class SetUpHandler : StateHandler
    {
        public override void Awake()
        {
            stateMachine = FindObjectOfType<StateMachine>();
            if (stateMachine != null)
            {
                stateMachine.RegisterStateHandler(State.SetUpGame, this);
            }
        }

        public override void OnEnter()
        {
            //generate GameLevel
            throw new System.NotImplementedException();
        }

        public override void OnExit()
        {
            //place player
            throw new System.NotImplementedException();
        }
    }
}