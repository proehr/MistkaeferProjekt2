using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityTemplateProjects
{
    public class WinHandler : StateHandler
    {
        [SerializeField] private CanvasGroup winScreen;
        public override void Awake()
        {
            stateMachine = FindObjectOfType<StateMachine>();
            if (stateMachine != null)
            {
                stateMachine.RegisterStateHandler(State.Win, this);
            }

            winScreen = transform.GetComponent<CanvasGroup>();
            winScreen.alpha = 0f;
            winScreen.interactable = false;
            winScreen.blocksRaycasts = false;
        }
        public override void OnEnter()
        {
            Time.timeScale = 0f;
            winScreen.alpha = 1f;
            winScreen.interactable = true;
            winScreen.blocksRaycasts = true;
        }

        public override void OnExit()
        {
            Time.timeScale = 1f;
            winScreen.alpha = 0f;
            winScreen.interactable = false;
            winScreen.blocksRaycasts = false;
        }

        public void LoadNextLevel()
        {
            stateMachine.TriggerTransition(Transition.StartGame);
        }
    }
}