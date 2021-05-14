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
        }
        public override void OnEnter()
        {
            Time.timeScale = 0f;
            winScreen.alpha = 1f;
            winScreen.interactable = true;
        }

        public override void OnExit()
        {
            Time.timeScale = 1f;
            winScreen.alpha = 0f;
            winScreen.interactable = false;
        }
    }
}