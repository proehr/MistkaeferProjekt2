public class GameOverCanvas : ACanvas
{
    protected override void Start()
    {
        HideCanvas();

        GameOverState.OnEnterGameOverEvent += ShowCanvas;
        GameOverState.OnEnterGameOverEvent += PauseTime;
        GameOverState.OnExitGameOverEvent += HideCanvas;
        GameOverState.OnExitGameOverEvent += ResumeTime;
    }

    public void ReturnToMainMenu()
    {
        StateMachine.TriggerTransition(Transition.EnterMainMenu);
    }


}