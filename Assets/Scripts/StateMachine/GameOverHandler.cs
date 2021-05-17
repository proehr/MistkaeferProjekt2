using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityTemplateProjects
{
    public class GameOverHandler : StateHandler
    {
        [SerializeField] private CanvasGroup gameOverScreen;
        public override void Awake()
        {
            stateMachine = FindObjectOfType<StateMachine>();
            if (stateMachine != null)
            {
                stateMachine.RegisterStateHandler(State.GameOver, this);
            }

            gameOverScreen = transform.GetComponent<CanvasGroup>();
            gameOverScreen.alpha = 0f;
            gameOverScreen.interactable = false;
            gameOverScreen.blocksRaycasts = false;
        }

        public override void OnEnter()
        {
            Time.timeScale = 0f;
            gameOverScreen.alpha = 1f;
            gameOverScreen.interactable = true;
            gameOverScreen.blocksRaycasts = true;
        }

        public override void OnExit()
        {
            Time.timeScale = 1f;
            gameOverScreen.alpha = 0f;
            gameOverScreen.interactable = false;
            gameOverScreen.blocksRaycasts = false;
        }

        public void ReturnToMainMenu()
        {
            stateMachine.TriggerTransition(Transition.StartGame);
        }
    }
}