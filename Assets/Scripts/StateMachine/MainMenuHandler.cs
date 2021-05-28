using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityTemplateProjects
{
    public class MainMenuHandler : StateHandler
    {
        [SerializeField] private CanvasGroup mainMenu;
        public override void Awake()
        {
            stateMachine = FindObjectOfType<StateMachine>();
            if (stateMachine != null)
            {
                stateMachine.RegisterStateHandler(State.MainMenu, this);
            }
            mainMenu = transform.GetComponent<CanvasGroup>();
            Time.timeScale = 0f;
            
        }
        public override void OnEnter()
        {
            Time.timeScale = 0f;
            mainMenu.alpha = 1f;
            mainMenu.interactable = true;
            mainMenu.blocksRaycasts = true;
        }

        public override void OnExit()
        {
            Time.timeScale = 1f;
            mainMenu.alpha = 0f;
            mainMenu.interactable = false;
            mainMenu.blocksRaycasts = false;
        }
    }
}