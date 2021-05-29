public class WinCanvas : ACanvas
{
    protected override void Start()
    {
        HideCanvas();

        WinState.OnEnterWinEvent += ShowCanvas;
        WinState.OnEnterWinEvent += PauseTime;
        WinState.OnExitWinEvent += HideCanvas;
        WinState.OnExitWinEvent += ResumeTime;
    }

    public void NextLevel()
    {
        StateMachine.TriggerTransition(Transition.SetUpGame);
    }
}