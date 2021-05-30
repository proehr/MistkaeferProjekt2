using UnityEngine;
using UnityEngine.SceneManagement;

    public class MainMenuState : State
    {
        private static State instance;
        public static event EnterEvent OnEnterMainMenuEvent;
        public static event ExitEvent OnExitMainMenuEvent;

        public override void OnEnter()
        {
            if (OnEnterMainMenuEvent != null)
            {
                OnEnterMainMenuEvent();
            }
        }

        public override void OnExit()
        {
            if (OnExitMainMenuEvent != null)
            {
                OnExitMainMenuEvent();
            }
        }

        /**
        * returns instance of MainMenuState and creates an instance if one doesn't exist
        */
        public static State GetInstance()
        {
            if (instance == null)
            {
                instance = new MainMenuState();
            }
            return instance;
        }
        
        private MainMenuState(){}
    }