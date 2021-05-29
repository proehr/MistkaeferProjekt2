using UnityEngine;

public class PauseCanvas: ACanvas
{
    protected override void Start()
    {
        HideCanvas();

        PauseState.OnEnterPauseEvent += ShowCanvas;
        PauseState.OnEnterPauseEvent += PauseTime;
        PauseState.OnExitPauseEvent += HideCanvas;
        PauseState.OnExitPauseEvent += ResumeTime;
    }


    public void ResumeGame()
    {
        StateMachine.TriggerTransition(Transition.PlayGame);
    }

    public void ResetToMainMenu()
    {
        StateMachine.TriggerTransition(Transition.EnterMainMenu);
    }
    
}