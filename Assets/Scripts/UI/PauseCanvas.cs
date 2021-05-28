public class PauseCanvas: ACanvas
{
    override protected void Start()
    {
        HideCanvas();

        PauseState.OnEnterPauseEvent += ShowCanvas;
        PauseState.OnExitPauseEvent += HideCanvas;
    }
}