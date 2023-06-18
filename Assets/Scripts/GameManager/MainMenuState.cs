using UnityEngine.SceneManagement;

public class MainMenuState : BaseGameState
{
	public MainMenuState(GameManager gameManager) : base(gameManager)
	{
	}

	public override void Enter()
	{
		SceneManager.LoadScene(Constants.MenuSceneName);

		var mainMenuController = new MainMenuController(_gameManager);
	}
}
