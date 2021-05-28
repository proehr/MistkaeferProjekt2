using UnityTemplateProjects;

public static class States
{
    public static State mainMenu = MainMenuState.GetInstance();
    public static State setUp = SetUpState.GetInstance();
    public static State play = PlayState.GetInstance();
    public static State pause = PauseState.GetInstance();
    public static State win = WinState.GetInstance();
    public static State gameOver = GameOverState.GetInstance();
}
