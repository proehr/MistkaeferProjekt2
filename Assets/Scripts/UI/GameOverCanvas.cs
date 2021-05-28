public class GameOverCanvas : ACanvas
{
    override protected void Start()
    {
        HideCanvas();

        GameOverState.OnEnterGameOverEvent += ShowCanvas;
        GameOverState.OnExitGameOverEvent += HideCanvas;
    }
}