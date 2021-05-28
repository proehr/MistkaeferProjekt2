public class WinCanvas : ACanvas
{
    override protected void Start()
    {
        HideCanvas();

        WinState.OnEnterWinEvent += ShowCanvas;
        WinState.OnExitWinEvent += HideCanvas;
    }
}