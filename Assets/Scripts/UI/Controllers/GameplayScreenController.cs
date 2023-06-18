public class GameplayScreenController
{
    public GameplayScreenController(GameManager gameManager)
    {
        var gameplayScreen = gameManager.UiManager.ShowView<GameplayScreen>();
        gameplayScreen.Init(gameManager.Data, gameManager.GameSettings);
    }
}
