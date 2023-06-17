public class MainMenuState : BaseGameState
{
	private MainMenuWindow _menuWindow;
	
	public MainMenuState(GameManager gameManager) : base(gameManager)
	{
	}

	public override void Enter()
	{
		_menuWindow = _gameManager.UiManager.ShowView<MainMenuWindow>();
		_menuWindow.OnStartClicked += (value) =>
		{
			_gameManager.DataModel.ResourcesBuildingsCount = value;
			_gameManager.SwitchState(GameState.Gammeplay);
		};
	}

	public override void Exit()
	{
		_menuWindow.Close();
	}
}
