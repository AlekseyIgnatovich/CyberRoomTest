using UnityEngine.SceneManagement;

public class MainMenuState : BaseGameState
{
	public MainMenuState(GameManager gameManager) : base(gameManager)
	{
	}

	public override void Enter()
	{
		SceneManager.LoadScene(Constants.MenuSceneName);
	
		var menuWindow = _gameManager.UiManager.ShowView<MainMenuWindow>();
		menuWindow.OnStartClicked += (value) =>
		{
			_gameManager.Data.ResourcesBuildingsCount = value;
			_gameManager.SwitchState(GameState.Gammeplay);
		};
	}
}
