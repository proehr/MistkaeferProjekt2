using UnityEngine;
using UnityEngine.SceneManagement;

    public class MainMenuState : State
    {
        public static event EnterEvent OnEnterMainMenuEvent;
        public static event ExitEvent OnExitMainMenuEvent;

        public override void OnEnter()
        {
            if (OnEnterMainMenuEvent != null)
            {
                OnEnterMainMenuEvent();
            }
            /*if (SceneManager.GetActiveScene().buildIndex != 0)
            {
                SceneManager.LoadScene(0);
            }*/
        }

        public override void OnExit()
        {
            if (OnExitMainMenuEvent != null)
            {
                OnExitMainMenuEvent();
            }
            /*SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);*/
        }

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