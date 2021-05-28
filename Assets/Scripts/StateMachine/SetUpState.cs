using Maze;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityTemplateProjects
{
    public class SetUpState : State
    {
        public static event EnterEvent OnEnterSetUpEvent;
        public static event ExitEvent OnExitSetUpEvent;

        public override void OnEnter()
        {
            if (OnEnterSetUpEvent != null)
            {
                OnEnterSetUpEvent();
            }
        }

        public override void OnExit()
        {
            if (OnExitSetUpEvent != null)
            {
                OnExitSetUpEvent();
            }
        }

        public static State GetInstance()
        {
            if (instance == null)
            {
                instance = new SetUpState();
            }

            return instance;
        }

        private SetUpState()
        {
        }
    }
}