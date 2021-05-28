
    using UnityEngine;

    public class MainMenuCanvas : ACanvas
    {
        protected override void Start()
        {
            MainMenuState.OnEnterMainMenuEvent += ShowCanvas;
            MainMenuState.OnExitMainMenuEvent += HideCanvas;
        }
    }
