public class MainMenuController
{
    public MainMenuController(GameManager gameManager)
    {
        var menuWindow = gameManager.UiManager.ShowView<MainMenuWindow>();
        menuWindow.OnStartClicked += (value) =>
        {
            gameManager.Data.ResourcesBuildingsCount = value;
            gameManager.SwitchState(GameState.Gammeplay);
        };
    }
}
