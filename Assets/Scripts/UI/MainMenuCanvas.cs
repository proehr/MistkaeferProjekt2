
    using UnityEngine;

    public class MainMenuCanvas : ACanvas
    {
        [SerializeField] private GameObject mainMenuBoard;
        
        protected override void Start()
        {
            MainMenuState.OnEnterMainMenuEvent += ShowCanvas;
            MainMenuState.OnEnterMainMenuEvent += ShowMainMenuBoard;
            MainMenuState.OnExitMainMenuEvent += HideCanvas;
            MainMenuState.OnExitMainMenuEvent += HideMainMenuBoard;
        }

        private void ShowMainMenuBoard()
        {
            mainMenuBoard.SetActive(true);
        }

        private void HideMainMenuBoard()
        {
            mainMenuBoard.SetActive(false);
        }
    }
