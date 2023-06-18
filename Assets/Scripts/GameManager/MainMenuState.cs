using UnityEngine.SceneManagement;

public class MainMenuState : BaseGameState
{
	private MainMenuController _mainMenuController;
	
	public MainMenuState(GameManager gameManager) : base(gameManager)
	{
	}

	public override void Enter()
	{
		SceneManager.LoadScene(Constants.MenuSceneName);

		_mainMenuController = new MainMenuController(_gameManager);
	}
}
